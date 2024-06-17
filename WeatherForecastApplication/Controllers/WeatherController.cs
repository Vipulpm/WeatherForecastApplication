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
        public async Task<IActionResult> GetWeather(string city)
        {
            if (string.IsNullOrEmpty(city))
            {
                ModelState.AddModelError(string.Empty, "Please enter a city name.");
                return View("Index");
            }

            string apiKey = "ca0b7d7c84f31afbd4050ecac4490e77"; // <= I have use my key here; You can use your own =>;
            string url = $"http://api.openweathermap.org/data/2.5/weather?q={city}&appid={apiKey}&units=metric";

            HttpResponseMessage response = await _httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                System.Diagnostics.Debug.WriteLine("API Response: " + responseBody);
                WeatherData weatherData = JsonConvert.DeserializeObject<WeatherData>(responseBody);
                return View("Index",weatherData);
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Could not retrieve weather data. Please try again.");
                return View("Index");
            }
        }
    }
}
