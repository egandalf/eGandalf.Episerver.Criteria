using eGandalf.Episerver.Criteria.Weather.Interfaces;
using eGandalf.Episerver.Criteria.Weather.Weather;
using EPiServer.Personalization.VisitorGroups;
using EPiServer.ServiceLocation;
using System.Security.Principal;
using System.Web;

namespace eGandalf.Episerver.Criteria.Weather.Criteria
{
    [VisitorGroupCriterion(
        Category = "Weather",
        Description = "Temperature-based personalization",
        DisplayName = "Temperature")]
    public class TemperatureCriterion : CriterionBase<TemperatureCriterionModel>
    {
        Injected<IWeatherService> _weatherService;

        public override bool IsMatch(IPrincipal principal, HttpContextBase httpContext)
        {
            var currentWeather = _weatherService.Service.GetCurrentConditions();

            if (currentWeather == null) return false;

            var temperature = TemperatureConversions.KelvinToC(currentWeather.CurrentConditions.TemperatureK);
            if (Model.TemperatureScale == Enums.TemperatureScale.Fahrenheit) temperature = TemperatureConversions.KelvinToF(currentWeather.CurrentConditions.TemperatureK);

            if (Model.Condition == Enums.Condition.EqualTo && temperature == Model.Temperature) return true;
            else if (Model.Condition == Enums.Condition.GreaterThan && temperature >= Model.Temperature) return true;
            else if (Model.Condition == Enums.Condition.LessThan && temperature < Model.Temperature) return true;

            return false;
        }
    }
}
