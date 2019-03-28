using Newtonsoft.Json;
using System.Collections.Generic;

namespace eGandalf.Episerver.Criteria.Weather.Weather.OpenWeatherMap
{
    /*
    {"coord":{"lon":139,"lat":35},
"sys":{"country":"JP","sunrise":1369769524,"sunset":1369821049},
"weather":[{"id":804,"main":"clouds","description":"overcast clouds","icon":"04n"}],
"main":{"temp":289.5,"humidity":89,"pressure":1013,"temp_min":287.04,"temp_max":292.04},
"wind":{"speed":7.31,"deg":187.002},
"rain":{"3h":0},
"clouds":{"all":92},
"dt":1369824698,
"id":1851632,
"name":"Shuzenji",
"cod":200}
 */
    [JsonObject]
    public class WeatherResponse
    {
        [JsonProperty("sys")]
        public SystemData SystemData { get; set; }

        [JsonProperty("weather")]
        public IEnumerable<WeatherData> WeatherData { get; set; }

        [JsonProperty("main")]
        public MainData MainData { get; set; }

        [JsonProperty("wind")]
        public WindData WindData { get; set; }

        [JsonProperty("rain")]
        public PrecipitationData RainData { get; set; }

        [JsonProperty("snow")]
        public PrecipitationData SnowData { get; set; }

        [JsonProperty("clouds.all")]
        public int? CloudinessPct { get; set; }
    }
}
