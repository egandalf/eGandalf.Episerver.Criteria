using Newtonsoft.Json;

namespace eGandalf.Episerver.Criteria.Weather.Weather.OpenWeatherMap
{
    public class PrecipitationData
    {
        [JsonProperty("3h")]
        public double? ThreeHourMetric { get; set; }

        [JsonProperty("1h")]
        public double? OneHourMetric { get; set; }
    }
}