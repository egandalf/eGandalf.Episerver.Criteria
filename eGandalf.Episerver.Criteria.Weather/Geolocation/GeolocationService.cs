using eGandalf.Episerver.Criteria.Weather.Settings;
using EPiServer.Personalization;
using EPiServer.ServiceLocation;
using System.Net;
using System.Web;

namespace eGandalf.Episerver.Criteria.Weather.Geolocation
{
    public class GeolocationService
    {
        private GeolocationProviderBase _geolocationProviderBase;

        public GeolocationService() : this(ServiceLocator.Current.GetInstance<GeolocationProviderBase>()) { }

        public GeolocationService(GeolocationProviderBase geolocationProviderBase)
        {
            _geolocationProviderBase = geolocationProviderBase;
        }

        public IGeolocationResult GetGeolocation(IPAddress ip)
        {
            IGeolocationResult result = _geolocationProviderBase.Lookup(ip);
            return result;
        }

        
    }
}
