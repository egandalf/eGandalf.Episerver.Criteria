using System;

namespace eGandalf.Episerver.Criteria.Weather.Interfaces
{
    public interface ICurrentConditions
    {
        string ConditionCategory { get; set; }
        string Description { get; set; }
        double TemperatureK { get; set; }
        double Pressure { get; set; }
        double Humidity { get; set; }
        double TemperatureMinK { get; set; }
        double TemperatureMaxK { get; set; }
        double WindSpeedMetric { get; set; }
        double WindDegrees { get; set; }
        double CloudinessPercent { get; set; }
        double? RainPastHourMetric { get; set; }
        double? RainPastThreeHoursMetric { get; set; }
        double? SnowPastHourMetric { get; set; }
        double? SnowPastThreeHoursMetric { get; set; }
        DateTime SunriseUnixUTC { get; set; }
        DateTime SunsetUnixUTC { get; set; }
    }
}
