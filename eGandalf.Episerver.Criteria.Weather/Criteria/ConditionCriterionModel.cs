using eGandalf.Episerver.Criteria.Weather.Enums;
using EPiServer.Personalization.VisitorGroups;
using EPiServer.Web.Mvc.VisitorGroups;
using System.ComponentModel.DataAnnotations;

namespace eGandalf.Episerver.Criteria.Weather.Criteria
{
    public class ConditionCriterionModel : CriterionModelBase
    {
        [Required]
        [DojoWidget(
            WidgetType = "dijit.form.FilteringSelect",
            SelectionFactoryType = typeof(EnumSelectionFactory))]
        public BasicCondition Condition { get; set; }

        [Required]
        [DojoWidget(
            WidgetType = "dijit.form.FilteringSelect",
            SelectionFactoryType = typeof(EnumSelectionFactory))]
        public WeatherCodes ConditionCode { get; set; }

        public override ICriterionModel Copy()
        {
            return base.ShallowCopy();
        }
    }
}
