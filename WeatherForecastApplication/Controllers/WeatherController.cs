using Microsoft.AspNetCore.Mvc;
using WeatherForecastApplication.Models;
using Newtonsoft.Json;

namespace WeatherForecastApplication.Controllers
{
    public class WeatherController : Controller
    {
        private readonly HttpClient _httpClient;
        public WeatherController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> GetWeather(string city, string district = null, string latitude = null, string longitude = null)
        {
            if (string.IsNullOrEmpty(city) && (string.IsNullOrEmpty(latitude) || string.IsNullOrEmpty(longitude)))
            {
                ModelState.AddModelError(string.Empty, "Please enter a city name or coordinates.");
                return View("Index");
            }

            string apiKey = "ca0b7d7c84f31afbd4050ecac4490e77"; // Use your own API key here
            string query = !string.IsNullOrEmpty(district) ? $"{district},{city}" : city;
            string url;

            if (!string.IsNullOrEmpty(latitude) && !string.IsNullOrEmpty(longitude))
            {
                url = $"http://api.openweathermap.org/data/2.5/weather?lat={latitude}&lon={longitude}&appid={apiKey}&units=metric";
            }
            else
            {
                url = $"http://api.openweathermap.org/data/2.5/weather?q={query}&appid={apiKey}&units=metric";
            }

            HttpResponseMessage response = await _httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                WeatherData weatherData = JsonConvert.DeserializeObject<WeatherData>(responseBody);
                return View("Weather", weatherData);
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Could not retrieve weather data. Please try again.");
                return View("Index");
            }
        }

    }
}
