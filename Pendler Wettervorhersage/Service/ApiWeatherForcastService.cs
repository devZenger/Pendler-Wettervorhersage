using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Pendler_Wettervorhersage
{
    internal class ApiWeatherForcastService
    {
        public WeatherApiResponse UseWeatherApi(string searchLocation)
        {
            searchLocation = searchLocation.Trim();

            int searchPlz;

            bool plz = int.TryParse(searchLocation, out searchPlz);

            string lat;
            string lon;
                

            if (plz)
            {
                PlzSearch plzSearch = new PlzSearch();

                List<PlzCsv> plzResult = plzSearch.SearchPlz(searchPlz);
                lat = plzResult[0].Latidude;
                lon = plzResult[0].Longitude;
                searchLocation = $"{lat}, {lon}";   
            }


            string apiKey = Properties.Settings.Default.ApiKey;
            string urlStart = "http://api.weatherapi.com/v1/forecast.json?key=";

            string days = "3";
       
            string requestUrl = $"{urlStart}{apiKey}&q={searchLocation}&days={days}&lang=de&aqi=no&alerts=no";

            HttpClient httpClient = new HttpClient();

            HttpResponseMessage httpResponseWeatherApi = httpClient.GetAsync(requestUrl).Result;

            string responseWeatherApi = httpResponseWeatherApi.Content.ReadAsStringAsync().Result;

            Console.WriteLine(responseWeatherApi);

            WeatherApiResponse? weatherApiRespone = JsonConvert.DeserializeObject<WeatherApiResponse>(responseWeatherApi);

            return weatherApiRespone;

        }
    }
}
