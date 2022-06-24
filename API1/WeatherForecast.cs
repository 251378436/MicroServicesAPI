using API1.Converters;
using System.Text.Json.Serialization;

namespace API1
{
    public class WeatherForecast
    {
        //[JsonConverter(typeof(CustomDateTimeConverter))]
        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string? Summary { get; set; }
    }
}