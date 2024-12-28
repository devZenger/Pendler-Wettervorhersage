using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Pendler_Wettervorhersage
{
    internal class GetWeatherForcast
    {
        public void UseWeatherApi(string searchLocation)
        {
            string apiKey = Properties.Settings.Default.ApiKey;
            string urlStart = "http://api.weatherapi.com/v1/forecast.json?key=";

            string days = "3";
            //string hours = "6";

            string requestUrl = $"{urlStart}{apiKey}&q={searchLocation}&days={days}&lang=de&aqi=no&alerts=no"; //&hour={hours}

            HttpClient httpClient = new HttpClient();

            HttpResponseMessage httpResponseWeatherApi = httpClient.GetAsync(requestUrl).Result;

            string responseWeatherApi = httpResponseWeatherApi.Content.ReadAsStringAsync().Result;

            //Console.WriteLine(responseWeatherApi);

            WeatherApiResponse weatherApiRespone = JsonConvert.DeserializeObject<WeatherApiResponse>(responseWeatherApi);

            int test = weatherApiRespone.Forecast.Forecastdays[0].Hours[4].WillItRain;

            Console.WriteLine(test);




            





        }
    }
}
