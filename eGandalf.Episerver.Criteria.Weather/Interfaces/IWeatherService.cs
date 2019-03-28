namespace eGandalf.Episerver.Criteria.Weather.Interfaces
{
    public interface IWeatherService
    {
        INormalizedWeatherData GetCurrentConditions();
    }
}
