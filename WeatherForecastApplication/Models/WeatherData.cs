namespace WeatherForecastApplication.Models
{
    public class WeatherData
    {
        public Main Main { get; set; }
        public string Name { get; set; }
    }

    public class Main
    {
        public double Temp { get; set; }
        public double Pressure { get; set; }
        public int Humidity { get; set; }
    }
}
