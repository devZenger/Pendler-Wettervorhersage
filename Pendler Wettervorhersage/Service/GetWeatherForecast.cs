using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pendler_Wettervorhersage
{
    internal class GetWeatherForecast
    {
        
        public List<ForecastReport> Process(SearchParameter searchParameter, bool germany)
        {
            ApiWeatherForcastService weatherResponse = new ApiWeatherForcastService();

           

            WeatherApiResponse forecastRaw = weatherResponse.UseWeatherApi(searchParameter.SearchLocation, germany);

            ForecastDataProcess forecastDataProcess = new ForecastDataProcess();

            List<ForecastReport> forecastProcessed = new List<ForecastReport>();

            forecastProcessed.AddRange(forecastDataProcess.GetProcess(forecastRaw, searchParameter));

            return forecastProcessed;
        }


    }
}
