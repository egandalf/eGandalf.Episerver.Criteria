using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace eGandalf.Episerver.Criteria.Weather.Weather.OpenWeatherMap
{
    public class OpenWeatherMapClient
    {
        public async Task<WeatherResponse> GetWeatherDataAsync(string url)
        {
            using (var httpClient = new HttpClient())
            {
                var json = await httpClient.GetStringAsync(url);
                return JsonConvert.DeserializeObject<WeatherResponse>(json);
            }
        }
    }
}
