using eGandalf.Episerver.Criteria.Weather.Enums;
using EPiServer.Personalization.VisitorGroups;
using EPiServer.Web.Mvc.VisitorGroups;
using System.ComponentModel.DataAnnotations;

namespace eGandalf.Episerver.Criteria.Weather.Criteria
{
    public class WindChillCriterionModel : CriterionModelBase
    {
        [Required]
        [DojoWidget(
            WidgetType = "dijit.form.FilteringSelect",
            SelectionFactoryType = typeof(EnumSelectionFactory))]
        public Condition Condition { get; set; }

        [Required]
        [Range(-30, 200)]
        public double Temperature { get; set; }

        [Required]
        [DojoWidget(
            WidgetType = "dijit.form.FilteringSelect",
            SelectionFactoryType = typeof(EnumSelectionFactory))]
        public TemperatureScale TemperatureScale { get; set; }

        public override ICriterionModel Copy()
        {
            return base.ShallowCopy();
        }
    }
}
