using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eGandalf.Episerver.Criteria.Weather.Weather
{
    public static class SpeedConversions
    {
        public static double MPStoKMPH(double mps)
        {
            return mps * 3.6;
        }

        public static double MPStoMPH(double mps)
        {
            return mps * 2.237;
        }
    }
}
