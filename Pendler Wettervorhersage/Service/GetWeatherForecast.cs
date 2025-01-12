using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pendler_Wettervorhersage
{
    internal class GetWeatherForecast
    {
        //private MainViewModel _mainViewModel;
        /*
        public void MainProcess(SearchParameter hometown, SearchParameter workplace)
        {

            WeatherApiResponse hometownForecastRaw = getWeather(hometown.SearchLocation);
            WeatherApiResponse workplaceForecastRaw = getWeather(workplace.SearchLocation);
    

            ForecastDataProcess forecastDataProcess = new ForecastDataProcess();

            List<ForecastReport> hometownForecastProcessd = new List<ForecastReport>();
            List<ForecastReport> workplaceForecastProcessed = new List<ForecastReport>();


            hometownForecastProcessd.AddRange(forecastDataProcess.GetProcess(hometownForecastRaw, hometown));

            workplaceForecastProcessed.AddRange(forecastDataProcess.GetProcess(workplaceForecastRaw, workplace));

            
            //_mainViewModel.UpdateHometownForecast(hometownForecastProcessd);
            //_mainViewModel.UpdateWorkplaceForecast(workplaceForecastProcessed);

        }

        internal WeatherApiResponse getWeather(string searchLoaction)
        {
            ApiWeatherForcastService weatherResponse = new ApiWeatherForcastService();

            return weatherResponse.UseWeatherApi(searchLoaction);
        }

        */


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
