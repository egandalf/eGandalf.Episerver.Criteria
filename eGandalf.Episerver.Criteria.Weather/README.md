# Episerver OpenWeatherMap API Criteria Collection

A collection of Episerver Visitor Group Criteria offering personalization / segmentation based on the _visitor's_ location and:

* Current Temperature (F or C)
* Wind Chill Adjusted Temperature (F or C)
* Wind Speed (m/s, MPH, kmph)
* General condition (cloudy, clear, dust, fog, thunderstorm, etc.)

Currently limited to current weather conditions. Multi-day forecast personalization is forthcoming in future updates.

## Prerequisites:

You must be running **Episerver CMS 11.6** or later (max version is currently 12) in order to support appropriate geolocation providers, such as MaxMind.

While you may use any provider correctly configured as such within the CMS, I tested with the MaxMind package: https://nuget.episerver.com/package/?id=EPiServer.Personalization.MaxMindGeolocation

A geolocation provider must be installed _and properly configured_ for this library to function correctly. I've added null checks and logging to help prevent catastrophic errors, but the library will not function without a GeoIP lookup.

## To configure:

Ensure you have the following settings in your configuration's AppSettings:

* **&lt;add key="OpenWeatherMapApiKey" value="*[Your OpenWeatherMap API Key]*" />** - Obtain your own key / subscription at: https://openweathermap.org/
* **&lt;add key="FallbackGeolocationIP" value="*[255.255.255.255]*" />** - This is a fallback IP address for geolocation. If you're running on localhost, an IP of 127.0.0.1 (or an IPv6 address of ::1) will result in a null response from GeoIP and subsequently fail the weather lookup. This is where you can configure an optional fallback IP address that the GeoIP lookup can use.
