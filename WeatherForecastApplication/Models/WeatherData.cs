using Newtonsoft.Json;
using System.Collections.Generic;

namespace WeatherForecastApplication.Models
{
    public class WeatherData
    {
        public Main Main { get; set; }
        public Wind Wind { get; set; }
        public Sys Sys { get; set; }
        public Rain Rain { get; set; }
        public string Name { get; set; }
        public int Visibility { get; set; }
        public List<Weather> Weather { get; set; }
    }

    public class Main
    {
        [JsonProperty("temp")]
        public double Temp { get; set; }

        [JsonProperty("feels_like")]
        public double FeelsLike { get; set; }

        [JsonProperty("temp_min")]
        public double TempMin { get; set; }

        [JsonProperty("temp_max")]
        public double TempMax { get; set; }

        public int Pressure { get; set; }
        public int Humidity { get; set; }
    }

    public class Wind
    {
        public double Speed { get; set; }
        public int Deg { get; set; }
    }

    public class Sys
    {
        public long Sunrise { get; set; }
        public long Sunset { get; set; }
        public string Country { get; set; }
    }

    public class Weather
    {
        public string Main { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }
    }

    public class Rain
    {
        [JsonProperty("1h")]
        public double? OneHour { get; set; }

        [JsonProperty("3h")]
        public double? ThreeHours { get; set; }
    }
}
