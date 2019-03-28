using System.Collections.Generic;

namespace eGandalf.Episerver.Criteria.Weather.Interfaces
{
    public interface IForecast
    {
        IEnumerable<IDay> Days { get; set; }
    }
}
