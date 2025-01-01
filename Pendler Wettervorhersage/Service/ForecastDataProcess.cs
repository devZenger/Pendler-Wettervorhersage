using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;

namespace Pendler_Wettervorhersage
{
    internal class ForecastDataProcess
    {

        public void start(string location, string timeString, int day) 
        {
            ApiWeatherForcastService useApi = new ApiWeatherForcastService();

            WeatherApiResponse rawForecastData = useApi.UseWeatherApi(location);

            
            int[] time = TimeToInt(timeString);
            

            ForecastData forecastData = new ForecastData();


            forecastData.Time = rawForecastData.Forecast.Forecastdays[day].Hours[time[0]].Time;
            decimal temp = rawForecastData.Forecast.Forecastdays[day].Hours[time[0]].TempC;
            decimal tempOneHourLater = rawForecastData.Forecast.Forecastdays[day].Hours[time[0] + 1].TempC;
            decimal tempAtMoment = ValueAtMinutes(temp, tempOneHourLater, time[1]);
            forecastData.TempC = tempAtMoment.ToString("F1") + "°C";
            forecastData.Discription = rawForecastData.Forecast.Forecastdays[day].Hours[time[0]].Condition.Text;
            forecastData.Icon = rawForecastData.Forecast.Forecastdays[day].Hours[time[0]].Condition.Icon;


            
          

        }

        public int[] TimeToInt(string timeInput)
        {
            string[] time = timeInput.Split();
            int[] timeInt = new int[2];
            timeInt[0] = Convert.ToInt32(time[0]);
            timeInt[1] = Convert.ToInt32(time[1]);
            return timeInt;
        }

        public decimal ValueAtMinutes(decimal one, decimal two, int minutes)
        {
            return (one + two)/60 * minutes;  
        } 

        
    }
}
