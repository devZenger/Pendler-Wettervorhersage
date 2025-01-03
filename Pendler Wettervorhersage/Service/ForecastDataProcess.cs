using System.Collections.Generic;

namespace Pendler_Wettervorhersage
{
    internal class ForecastDataProcess
    {

        public List<ForecastReport> GetProcess(WeatherApiResponse rawForecastData, SearchParameter searchInput)
        {
            List<ForecastReport> forecastReportForPanels = new List<ForecastReport>();
  
            for (int i = 0; i < 3; i++)
            {
                forecastReportForPanels.Add(SingleDayForecast(rawForecastData, searchInput.StartTime, i));
                forecastReportForPanels.Add(SingleDayForecast(rawForecastData, searchInput.EndTime, i));
            }
            return forecastReportForPanels;
        }


        internal ForecastReport SingleDayForecast(WeatherApiResponse rawForecastData, string timeString, int day)
        {
            //int[] time = TimeToInt(timeString);

            ForecastReport forecastReport = new ForecastReport();




            forecastReport.TitleDay = "angekommen";
            forecastReport.ApiWeatherDiscription = "sonnig";
            forecastReport.TemperaturC = "5°C";
            forecastReport.WindChillTempC = "7°";
            forecastReport.AddtionalInformation = "geh baden";






            //forecastReport.TitleDay = rawForecastData.Forecast.Forecastdays[day].Hours[time[0]].Time;
            //decimal temp = rawForecastData.Forecast.Forecastdays[day].Hours[time[0]].TempC;
            //decimal tempOneHourLater = rawForecastData.Forecast.Forecastdays[day].Hours[time[0] + 1].TempC;
            //decimal tempAtMoment = ValueAtMinutes(temp, tempOneHourLater, time[1]);
            //forecastReport.TemperaturC = tempAtMoment.ToString("F1") + "°C";
            //forecastReport.Discription = rawForecastData.Forecast.Forecastdays[day].Hours[time[0]].Condition.Text;
            //forecastReport. = rawForecastData.Forecast.Forecastdays[day].Hours[time[0]].Condition.Icon;






       

            return forecastReport;
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
