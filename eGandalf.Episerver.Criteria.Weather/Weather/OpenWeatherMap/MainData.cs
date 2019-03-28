using Newtonsoft.Json;

namespace eGandalf.Episerver.Criteria.Weather.Weather.OpenWeatherMap
{
    public class MainData
    {
        // "main":{"temp":289.5,"humidity":89,"pressure":1013,"temp_min":287.04,"temp_max":292.04},

        [JsonProperty("temp")]
        public double TemperatureKelvin { get; set; }

        [JsonProperty("humidity")]
        public double Humidity { get; set; }

        [JsonProperty("pressure")]
        public int Pressure { get; set; }

        [JsonProperty("temp_min")]
        public double TemperatureKelvinMin { get; set; }

        [JsonProperty("temp_max")]
        public double TemperatureKelvinMax { get; set; }
    }
}