using eGandalf.Episerver.Criteria.Weather.Interfaces;

namespace eGandalf.Episerver.Criteria.Weather.Weather
{
    public class NormalizedWeatherData : INormalizedWeatherData
    {
        public ICurrentConditions CurrentConditions { get; set; }
        public IForecast Forecast { get; set; }
    }
}
