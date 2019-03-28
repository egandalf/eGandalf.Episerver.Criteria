using eGandalf.Episerver.Criteria.Weather.Enums;
using EPiServer.Personalization.VisitorGroups;
using EPiServer.Web.Mvc.VisitorGroups;
using System.ComponentModel.DataAnnotations;

namespace eGandalf.Episerver.Criteria.Weather.Criteria
{
    public class WindCriterionModel : CriterionModelBase
    {
        [Required]
        [DojoWidget(
            WidgetType = "dijit.form.FilteringSelect",
            SelectionFactoryType = typeof(EnumSelectionFactory))]
        public Condition Condition { get; set; }

        [Required]
        public double WindSpeed { get; set; }

        [Required]
        [DojoWidget(
            WidgetType = "dijit.form.FilteringSelect",
            SelectionFactoryType = typeof(EnumSelectionFactory))]
        public WindSpeedUnit WindSpeedUnit { get; set; }

        public override ICriterionModel Copy()
        {
            return base.ShallowCopy();
        }
    }
}
