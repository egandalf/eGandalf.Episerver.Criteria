using Newtonsoft.Json;

namespace eGandalf.Episerver.Criteria.Weather.Weather.OpenWeatherMap
{
    public class WindData
    {
        // "wind":{"speed":7.31,"deg":187.002},
        [JsonProperty("speed")]
        public double Speed { get; set; }

        [JsonProperty("deg")]
        public double Degrees { get; set; }
    }
}