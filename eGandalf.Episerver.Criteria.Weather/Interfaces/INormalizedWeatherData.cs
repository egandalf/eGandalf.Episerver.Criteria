namespace eGandalf.Episerver.Criteria.Weather.Interfaces
{
    public interface INormalizedWeatherData
    {
        ICurrentConditions CurrentConditions { get; set; }
        IForecast Forecast { get; set; }
    }
}
