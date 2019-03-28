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
        Description = "Wind Chill personalization",
        DisplayName = "Wind Chill Temperature")]
    public class WindChillCriterion : CriterionBase<TemperatureCriterionModel>
    {
        Injected<IWeatherService> _weatherService;

        public override bool IsMatch(IPrincipal principal, HttpContextBase httpContext)
        {
            var currentWeather = _weatherService.Service.GetCurrentConditions();

            if (currentWeather == null) return false;

            var Tf = TemperatureConversions.KelvinToF(currentWeather.CurrentConditions.TemperatureK);
            var Wmph = SpeedConversions.MPStoMPH(currentWeather.CurrentConditions.WindSpeedMetric);

            double TwcF = Tf;

            // Wind chill calculations don't work (and aren't meaningful) for winds of less than 3MPH.
            if(Wmph >= 3) TwcF = TemperatureConversions.CalculatedWindChill(Tf, Wmph);

            var temperature = TwcF;
            if (Model.TemperatureScale == Enums.TemperatureScale.Celcius) temperature = TemperatureConversions.FahrenheitToCelcius(TwcF);

            if (Model.Condition == Enums.Condition.EqualTo && temperature == Model.Temperature) return true;
            else if (Model.Condition == Enums.Condition.GreaterThan && temperature >= Model.Temperature) return true;
            else if (Model.Condition == Enums.Condition.LessThan && temperature < Model.Temperature) return true;

            return false;
        }
    }
}
