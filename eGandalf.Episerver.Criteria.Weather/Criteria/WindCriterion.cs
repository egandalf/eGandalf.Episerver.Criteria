using eGandalf.Episerver.Criteria.Weather.Weather;
using EPiServer.Personalization.VisitorGroups;
using EPiServer.ServiceLocation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace eGandalf.Episerver.Criteria.Weather.Criteria
{
    [VisitorGroupCriterion(
        Category = "Weather",
        Description = "Wind-speed personalization",
        DisplayName = "Wind Speed")]
    public class WindCriterion : CriterionBase<WindCriterionModel>
    {
        Injected<WeatherService> _weatherService;

        public override bool IsMatch(IPrincipal principal, HttpContextBase httpContext)
        {
            var currentWeather = _weatherService.Service.GetCurrentConditions();

            if (currentWeather == null) return false;

            var windSpeed = currentWeather.CurrentConditions.WindSpeedMetric;
            if (Model.WindSpeedUnit == Enums.WindSpeedUnit.MilesPerHour) windSpeed = SpeedConversions.MPStoMPH(windSpeed);
            else if (Model.WindSpeedUnit == Enums.WindSpeedUnit.KilometersPerHour) windSpeed = SpeedConversions.MPStoKMPH(windSpeed);

            if (Model.Condition == Enums.Condition.EqualTo && windSpeed == Model.WindSpeed) return true;
            else if (Model.Condition == Enums.Condition.GreaterThan && windSpeed >= Model.WindSpeed) return true;
            else if (Model.Condition == Enums.Condition.LessThan && windSpeed < Model.WindSpeed) return true;

            return false;
        }
    }
}
