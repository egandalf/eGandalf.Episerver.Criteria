using Newtonsoft.Json;

namespace eGandalf.Episerver.Criteria.Weather.Weather.OpenWeatherMap
{
    public class WeatherData
    {
        [JsonProperty("main")]
        public string Main { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }
    }
}