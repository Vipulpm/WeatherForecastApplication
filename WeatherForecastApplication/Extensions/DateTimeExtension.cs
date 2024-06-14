namespace WeatherForecastApplication.Extensions
{
    public static class DateTimeExtension
    {
        public static DateTime ToLocalTime(this long unixTimeStamp)
        {
            DateTimeOffset dateTimeOffset = DateTimeOffset.FromUnixTimeSeconds(unixTimeStamp);
            return dateTimeOffset.LocalDateTime;
        }
    }
}
