using System.Collections.Generic;

namespace Pendler_Wettervorhersage
{
    internal class ForecastDataProcess
    {

        public List<ForecastData> GetProcess(WeatherApiResponse rawForecastData, SearchParameter searchInput)
        {
            List<ForecastData> forecastInfosForPanels = new List<ForecastData>();
  
            for (int i = 0; i < 3;)
            {
                forecastInfosForPanels.Add(SingleDayForecast(rawForecastData, searchInput.StartTime, i));
                forecastInfosForPanels.Add(SingleDayForecast(rawForecastData, searchInput.EndTime, i));
            }
            return forecastInfosForPanels;
        }


        internal ForecastData SingleDayForecast(WeatherApiResponse rawForecastData, string timeString, int day)
        {
            int[] time = TimeToInt(timeString);

            ForecastData.ForecastReport forecastReport = new ForecastData.ForecastReport();

            


            forecastReport.Time = rawForecastData.Forecast.Forecastdays[day].Hours[time[0]].Time;
            decimal temp = rawForecastData.Forecast.Forecastdays[day].Hours[time[0]].TempC;
            decimal tempOneHourLater = rawForecastData.Forecast.Forecastdays[day].Hours[time[0] + 1].TempC;
            decimal tempAtMoment = ValueAtMinutes(temp, tempOneHourLater, time[1]);
            forecastReport.TempC = tempAtMoment.ToString("F1") + "°C";
            forecastReport.Discription = rawForecastData.Forecast.Forecastdays[day].Hours[time[0]].Condition.Text;
            forecastReport.Icon = rawForecastData.Forecast.Forecastdays[day].Hours[time[0]].Condition.Icon;






            ForecastData forecastData = new ForecastData(forecastReport);

            return forecastData;
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
            return (one + two) / 60 * minutes;
        }


    }
}
