using eGandalf.Episerver.Criteria.Weather.Settings;
using System;
using System.Net;
using System.Web;

namespace eGandalf.Episerver.Criteria.Weather.Geolocation
{
    public static class IpFunctions
    {
        public static IPAddress GetUserIP()
        {
            string usersIP;
            if (HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"] != null)
            {
                usersIP = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"].ToString();
            }
            else
            {
                usersIP = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
            }

            IPAddress address = IPAddress.Parse(usersIP);
            if (string.IsNullOrEmpty(AssemblySettings.FallbackGeolocationIP) && IPAddress.IsLoopback(address))
                return null;

            if(IPAddress.IsLoopback(address))
                address = IPAddress.Parse(AssemblySettings.FallbackGeolocationIP);

            return address;
        }

        public static IPAddress GetNetworkAddress(this IPAddress address, IPAddress subnetMask)
        {
            byte[] ipAdressBytes = address.GetAddressBytes();
            byte[] subnetMaskBytes = subnetMask.GetAddressBytes();

            if (ipAdressBytes.Length != subnetMaskBytes.Length)
                throw new ArgumentException("Lengths of IP address and subnet mask do not match.");

            byte[] broadcastAddress = new byte[ipAdressBytes.Length];
            for (int i = 0; i < broadcastAddress.Length; i++)
            {
                broadcastAddress[i] = (byte)(ipAdressBytes[i] & (subnetMaskBytes[i]));
            }
            return new IPAddress(broadcastAddress);
        }
    }
}
