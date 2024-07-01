namespace WeatherForecastApplication.Models
{
    public class ForecastModel
    {
        public double latitude { get; set; }
        public double longitude { get; set; }
        public double generationtime_ms { get; set; }
        public int utc_offset_seconds { get; set; }
        public string timezone { get; set; }
        public string timezone_abbreviation { get; set; }
        public double elevation { get; set; }
        public weatherUnitsDTO current_weather_units { get; set; }
        public currentWeatherDTO current_weather { get; set; }
        public weatherUnitsDTO hourly_units { get; set; }
        public hourlyDTO hourly { get; set; }
        public weatherUnitsDTO daily_units { get; set; }
        public dailyDTO daily { get; set; }
    }

    public class weatherUnitsDTO
    {
        public string time { get; set; }
        public string interval { get; set; }
        public string temperature { get; set; }
        public string windspeed { get; set; }
        public string winddirection { get; set; }
        public string is_day { get; set; }
        public string weathercode { get; set; }
    }
    public class currentWeatherDTO
    {
        public string time { get; set; }
        public int interval { get; set; }
        public double temperature { get; set; }
        public double windspeed { get; set; }
        public int winddirection { get; set; }
        public int is_day { get; set; }
        public int weathercode { get; set; }
    }
    public class hourlyDTO
    {
        public List<string> time { get; set; }
        public List<double> temperature_2m { get; set; }
        public List<double> windspeed_10m { get; set; }
        public List<int> weathercode { get; set; }
    }
    public class dailyDTO
    {
        public List<string> time { get; set; }
        public List<double> temperature_2m_max { get; set; }
        public List<double> temperature_2m_min { get; set; }
        public List<int> weathercode { get; set; }
    }
}
