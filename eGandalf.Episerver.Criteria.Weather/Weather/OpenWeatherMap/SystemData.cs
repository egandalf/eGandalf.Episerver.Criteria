using Newtonsoft.Json;
using System;

namespace eGandalf.Episerver.Criteria.Weather.Weather.OpenWeatherMap
{
    public class SystemData
    {
        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("sunrise")]
        public long SunriseEpochSeconds { get; set; }

        [JsonProperty("sunset")]
        public long SunsetEpochSeconds { get; set; }

        public DateTime Sunrise
        {
            get
            {
                var ret = new DateTime(1970, 1, 1);
                return ret.AddSeconds(SunriseEpochSeconds);
            }
        }
        public DateTime Sunset {
            get
            {
                var ret = new DateTime(1970, 1, 1);
                return ret.AddSeconds(SunsetEpochSeconds);
            }
        }
    }
}