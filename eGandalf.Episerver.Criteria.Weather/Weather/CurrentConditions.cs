using eGandalf.Episerver.Criteria.Weather.Interfaces;
using System;

namespace eGandalf.Episerver.Criteria.Weather.Weather
{
    public class CurrentConditions : ICurrentConditions
    {
        public string ConditionCategory { get; set; }
        public string Description { get; set; }
        public double TemperatureK { get; set; }
        public double Pressure { get; set; }
        public double Humidity { get; set; }
        public double TemperatureMinK { get; set; }
        public double TemperatureMaxK { get; set; }
        public double WindSpeedMetric { get; set; }
        public double WindDegrees { get; set; }
        public double CloudinessPercent { get; set; }
        public double? RainPastHourMetric { get; set; }
        public double? RainPastThreeHoursMetric { get; set; }
        public DateTime SunriseUnixUTC { get; set; }
        public DateTime SunsetUnixUTC { get; set; }
        public double? SnowPastHourMetric { get; set; }
        public double? SnowPastThreeHoursMetric { get; set; }
    }
}
