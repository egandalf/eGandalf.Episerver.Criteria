namespace eGandalf.Episerver.Criteria.Weather.Interfaces
{
    public interface IDay
    {
        double TemperatureLow { get; set; }
        double TemperatureHigh { get; set; }
        string Condition { get; set; }
        double WindSpeed { get; set; }
    }
}
