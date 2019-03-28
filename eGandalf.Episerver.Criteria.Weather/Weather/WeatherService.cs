using eGandalf.Episerver.Criteria.Weather.Geolocation;
using eGandalf.Episerver.Criteria.Weather.Interfaces;
using eGandalf.Episerver.Criteria.Weather.Settings;
using eGandalf.Episerver.Criteria.Weather.Weather.OpenWeatherMap;
using EPiServer.Logging;
using EPiServer.ServiceLocation;
using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Caching;

namespace eGandalf.Episerver.Criteria.Weather.Weather
{
    [ServiceConfiguration(typeof(IWeatherService), Lifecycle = ServiceInstanceScope.Singleton)]
    public class WeatherService : IWeatherService
    {
        private static readonly OpenWeatherMapClient weatherMapClient = new OpenWeatherMapClient();
        private const string _urlBase = "https://api.openweathermap.org/data/2.5/weather";
        private static readonly ILogger Logger = LogManager.GetLogger();


        public INormalizedWeatherData GetCurrentConditions()
        {
            var Ip = IpFunctions.GetUserIP();

            if (Ip == null)
            {
                Logger.Critical("Unable to obtain IP targetable IP address. If running locally, set FallbackGeolocationIP in AppSettings to a geo-targetable IP address.");
                return null;
            }

            var NetAddress = IpFunctions.GetNetworkAddress(Ip, IPAddress.Parse("255.255.255.0"));

            // cache based on subnet to reduce goe-based calls for highly similar IP addresses
            // TODO: 30minute cache - consider making a config value?
            return CacheAside.GetOrAddAbsoluteCache(NetAddress.ToString(), () => GetWeatherData(), DateTime.Now.AddMinutes(30));            
        }

        public INormalizedWeatherData GetWeatherData()
        {
            var GeoService = new GeolocationService();
            var Ip = IpFunctions.GetUserIP();

            if (Ip == null)
            {
                Logger.Critical("Unable to obtain IP targetable IP address. If running locally, set FallbackGeolocationIP in AppSettings to a geo-targetable IP address.");
                return null;
            }

            var geodata = GeoService.GetGeolocation(Ip);

            if (geodata == null)
            {
                Logger.Critical("Unable to retrieve geolocation data for the provided IP address. Have you correctly installed and configured a Geolocation provider?");
                return null;
            }

            var url = $"{_urlBase}?lat={geodata.Location.Latitude}&lon={geodata.Location.Longitude}&appid={AssemblySettings.OpenWeatherMapApiKey}";

            WeatherResponse response;
            try
            {
                response = Task.Run(async () => await weatherMapClient.GetWeatherDataAsync(url)).Result;
            }
            catch(Exception ex)
            {
                Logger.Critical(ex.Message, ex);
                return null;
            }

            var weather = new NormalizedWeatherData
            {
                CurrentConditions = new CurrentConditions
                {
                    CloudinessPercent = response.CloudinessPct.HasValue ? response.CloudinessPct.Value : -1,
                    ConditionCategory = response.WeatherData.First().Main,
                    Description = response.WeatherData.First().Description,
                    Humidity = response.MainData.Humidity,
                    Pressure = response.MainData.Pressure,
                    RainPastHourMetric = response.RainData?.OneHourMetric,
                    RainPastThreeHoursMetric = response.RainData?.ThreeHourMetric,
                    SnowPastHourMetric = response.SnowData?.OneHourMetric,
                    SnowPastThreeHoursMetric = response.SnowData?.ThreeHourMetric,
                    SunriseUnixUTC = response.SystemData.Sunrise,
                    SunsetUnixUTC = response.SystemData.Sunset,
                    TemperatureK = response.MainData.TemperatureKelvin,
                    TemperatureMaxK = response.MainData.TemperatureKelvinMax,
                    TemperatureMinK = response.MainData.TemperatureKelvinMin,
                    WindDegrees = response.WindData.Degrees,
                    WindSpeedMetric = response.WindData.Speed
                }
            };

            return weather;
        }
    }
}
