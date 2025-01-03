using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pendler_Wettervorhersage
{
    internal class GetWeatherForecast
    {
        private MainViewModel _mainViewModel;

        public GetWeatherForecast(MainViewModel mainViewModel)
        {
            _mainViewModel = mainViewModel;
        }

        public void MainProcess(SearchParameter hometown, SearchParameter workplace)
        {
            WeatherApiResponse hometownForecastRaw = getWeather(hometown.SearchLocation);
            
            WeatherApiResponse workplaceForecastRaw = getWeather(workplace.SearchLocation);
    
            ForecastDataProcess forecastDataProcess = new ForecastDataProcess();

            List<ForecastReport> hometownForecastProcessd = new List<ForecastReport>();
            
            List<ForecastReport> workplaceForecastProcessed = new List<ForecastReport>();

            hometownForecastProcessd.AddRange(forecastDataProcess.GetProcess(hometownForecastRaw, hometown));

            workplaceForecastProcessed = forecastDataProcess.GetProcess(workplaceForecastRaw, workplace);

            


            //_mainViewModel.HometownPanels[0].TitleDay = hometownForecastProcessd[0].Forecast.Time;

           


        }

        internal WeatherApiResponse getWeather(string searchLoaction)
        {
            ApiWeatherForcastService weatherResponse = new ApiWeatherForcastService();

            return weatherResponse.UseWeatherApi(searchLoaction);
        }
    }
}
