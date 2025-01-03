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
                forecastReportForPanels[forecastReportForPanels.Count - 1].TitleDay = forecastReportForPanels[forecastReportForPanels.Count - 1].TitleDay = ""; 
            }
            return forecastReportForPanels;
        }


        internal ForecastReport SingleDayForecast(WeatherApiResponse rawForecastData, string timeString, int day)
        {
            int[] time = TimeToInt(timeString);

            ForecastReport forecastReport = new ForecastReport();




            forecastReport.TitleDay = "angekommen";
            forecastReport.ApiWeatherDiscription = "sonnig";
            forecastReport.TemperaturC = "5°C";
            forecastReport.FeelsLikeTempC = "7°";
            forecastReport.AddtionalInformation = "geh baden";




            if (day == 0) 
                forecastReport.TitleDay = "Heute";
            if (day == 1)
                forecastReport.TitleDay = "Morgen";
            if (day == 2)
            {
                string timeApi = rawForecastData.Forecast.Forecastdays[day].Hours[time[0]].Time;
                DateTime dateTime = DateTime.Parse(timeApi);
                string formattedDate = dateTime.ToString("d.M.yyyy");
                forecastReport.TitleDay = formattedDate;
            }

      
            decimal temp = rawForecastData.Forecast.Forecastdays[day].Hours[time[0]].TempC;      
            decimal tempOneHourLater = rawForecastData.Forecast.Forecastdays[day].Hours[time[0] + 1].TempC;
            forecastReport.TemperaturC = $"{ValueAtMinutes(temp, tempOneHourLater, time[1])} °C";


            decimal feelTemp = rawForecastData.Forecast.Forecastdays[day].Hours[time[0]].FeelsLikeC;
            decimal feelTempHourLater = rawForecastData.Forecast.Forecastdays[day].Hours[time[0]].FeelsLikeC;
            forecastReport.FeelsLikeTempC = $"{ValueAtMinutes(feelTemp, feelTempHourLater, time[1])} °C";


            //forecastReport.Discription = rawForecastData.Forecast.Forecastdays[day].Hours[time[0]].Condition.Text;
            //forecastReport. = rawForecastData.Forecast.Forecastdays[day].Hours[time[0]].Condition.Icon;








            return forecastReport;
        }

        public int[] TimeToInt(string timeInput)
        {
            string[] time = timeInput.Split(":");
            int[] timeInt = new int[2];
            timeInt[0] = Convert.ToInt32(time[0]);
            timeInt[1] = Convert.ToInt32(time[1]);
            return timeInt;
        }

        public string ValueAtMinutes(decimal one, decimal two, int minutes)
        {
            return ((one + two) / 60 * minutes + one).ToString("F1");   
           
        }








    }
}
