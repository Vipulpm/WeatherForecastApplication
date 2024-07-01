using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WeatherForecastApplication.Models;

namespace WeatherForecastApplication.Controllers
{
    public class ForeCastController : Controller
    {
        private readonly IHttpClientFactory _clientFactory;
        //private readonly string _apiKey = "ca0b7d7c84f31afbd4050ecac4490e77";

        public ForeCastController(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> GetWeatherForecast(string latitude, string longitude)
        {
            if (string.IsNullOrEmpty(latitude) || string.IsNullOrEmpty(longitude))
            {
                ModelState.AddModelError(string.Empty, "Please enter valid latitude and longitude.");
                return View("Index");
            }

            string url = $"https://api.open-meteo.com/v1/forecast?latitude={latitude}&longitude={longitude}&current_weather=true&hourly=temperature_2m,windspeed_10m,weathercode&daily=temperature_2m_max,temperature_2m_min,weathercode";

            try
            {
                var httpClient = _clientFactory.CreateClient();
                HttpResponseMessage response = await httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();

                    ForecastModel weatherData = JsonConvert.DeserializeObject<ForecastModel>(responseBody);

                    // Initialize null properties to avoid NullReferenceException
                    weatherData.current_weather ??= new currentWeatherDTO();
                    weatherData.hourly ??= new hourlyDTO { time = new List<string>(), temperature_2m = new List<double>(), windspeed_10m = new List<double>(), weathercode = new List<int>() };
                    weatherData.daily ??= new dailyDTO { time = new List<string>(), temperature_2m_max = new List<double>(), temperature_2m_min = new List<double>(), weathercode = new List<int>() };

                    return View("Index", weatherData);
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Could not retrieve weather data. Please try again.");
                    return View("Index");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"An error occurred: {ex.Message}");
                return View("Index");
            }
        }
    }
}
