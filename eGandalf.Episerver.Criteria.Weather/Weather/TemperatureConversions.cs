using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eGandalf.Episerver.Criteria.Weather.Weather
{
    internal static class TemperatureConversions
    {
        internal static double KelvinToF(double K)
        {
            var F = (9 / 5) * (K - 273) + 32;
            return F;
        }

        internal static double KelvinToC(double K)
        {
            return K - 273.15;
        }

        internal static double FahrenheitToCelcius(double F)
        {
            return (F - 32) / 1.8;
        }

        internal static double CalculatedWindChill(double Tf, double Wmph)
        {
            return 35.74 + (0.6215 * Tf) - (35.75 * Math.Pow(Wmph, 0.16)) + (0.4275 * Tf * Math.Pow(Wmph, 0.16));
        }
    }
}
