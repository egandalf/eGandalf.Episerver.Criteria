using eGandalf.Episerver.Criteria.Weather.Enums;
using eGandalf.Episerver.Criteria.Weather.Interfaces;
using EPiServer.Personalization.VisitorGroups;
using EPiServer.ServiceLocation;
using System;
using System.Security.Principal;
using System.Web;

namespace eGandalf.Episerver.Criteria.Weather.Criteria
{
    [VisitorGroupCriterion(
        Category = "Weather",
        Description = "General weather condition personalization",
        DisplayName = "General Condition")]
    public class ConditionCriterion : CriterionBase<ConditionCriterionModel>
    {
        Injected<IWeatherService> _weatherService;

        public override bool IsMatch(IPrincipal principal, HttpContextBase httpContext)
        {
            var currentWeather = _weatherService.Service.GetCurrentConditions();

            if (currentWeather == null) return false;

            var condition = currentWeather.CurrentConditions.ConditionCategory;

            WeatherCodes code;
            if(Enum.TryParse(condition, out code))
            {
                if (Model.Condition == BasicCondition.Is && Model.ConditionCode == code) return true;
                else if (Model.Condition == BasicCondition.IsNot && Model.ConditionCode != code) return true;
            }

            return false;
        }
    }
}
