using Pendler_Wettervorhersage.Service;
using System.Collections.Generic;
using System.Globalization;
using System.Windows;

namespace Pendler_Wettervorhersage
{
    internal class ForecastDataProcess
    {
        public List<ForecastReport> GetProcess(WeatherApiResponse rawForecastData, SearchParameter searchInput)
        {
            List<ForecastReport> forecastReportForPanels = new List<ForecastReport>();

            if (rawForecastData.Error != null && rawForecastData.Error.Code != 0)
            {
                    throw new Exception(rawForecastData.Error.Message);   
            }
            else { 
            for (int i = 0; i < 3; i++)
            {
                forecastReportForPanels.Add(SingleDayForecast(rawForecastData, searchInput.StartTime, i));
                forecastReportForPanels.Add(SingleDayForecast(rawForecastData, searchInput.EndTime, i));
                forecastReportForPanels[forecastReportForPanels.Count - 1].TitleDay = forecastReportForPanels[forecastReportForPanels.Count - 1].TitleDay = ""; 
            }
            }
            return forecastReportForPanels;
        }
        private ForecastReport SingleDayForecast(WeatherApiResponse rawForecastData, string timeString, int day)
        {
            int[] time = TimeToInt(timeString);

            ForecastReport forecastReport = new ForecastReport();


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

            // Temperatur
            decimal temp = rawForecastData.Forecast.Forecastdays[day].Hours[time[0]].TempC;      
            decimal tempOneHourLater = rawForecastData.Forecast.Forecastdays[day].Hours[time[0] + 1].TempC;
            forecastReport.TemperaturC = $"{ValueAtMinutes(temp, tempOneHourLater, time[1])} °C";

            // Feelslike Temperatur
            decimal feelTemp = rawForecastData.Forecast.Forecastdays[day].Hours[time[0]].FeelsLikeC;
            decimal feelTempHourLater = rawForecastData.Forecast.Forecastdays[day].Hours[time[0]].FeelsLikeC;
            forecastReport.FeelsLikeTempC = $"{ValueAtMinutes(feelTemp, feelTempHourLater, time[1])} °C";

            //Icon 
            WeatherIconsPath iconPath = new WeatherIconsPath();
            
            string sunrise = rawForecastData.Forecast.Forecastdays[day].Astro.Sunrise;
            string sunset = rawForecastData.Forecast.Forecastdays[day].Astro.Sunset;

            bool dayLight = CheckDayLight(timeString, sunrise, sunset);
            
            forecastReport.IconPath = iconPath.GetIconPath(rawForecastData.Forecast.Forecastdays[day].Hours[time[0]].Condition.Code, dayLight);
                
  
            //Api discription
            forecastReport.ApiWeatherDiscription = rawForecastData.Forecast.Forecastdays[day].Hours[time[0]].Condition.Text;

            //Addtional Discriptopn
            int chanceOfRain = rawForecastData.Forecast.Forecastdays[day].Hours[time[0]].ChanceOfRain;
            int chanceOfSnow = rawForecastData.Forecast.Forecastdays[day].Hours[time[0]].ChanceOfSnow;

            if (chanceOfRain > 0 && chanceOfSnow > 0)
                forecastReport.AddtionalInformation = $"Regen.: {chanceOfRain}%, Schnee.: {chanceOfSnow}%";
            else if (chanceOfRain > 0 && chanceOfSnow == 0)
                forecastReport.AddtionalInformation = $"Regen.: {chanceOfRain}%";
            else if (chanceOfRain == 0 && chanceOfSnow > 0)
                forecastReport.AddtionalInformation = $"Schneefall.: {chanceOfSnow}";
            else
                forecastReport.AddtionalInformation = string.Empty;

            //Location
            forecastReport.Name = $"Name: {rawForecastData.Location.Name}";
            forecastReport.Region = $"Region: {rawForecastData.Location.Region}";
            forecastReport.Country = $"Country: {rawForecastData.Location.Country}";

            return forecastReport;
        }
        private int[] TimeToInt(string timeInput)
        {
            string[] time = timeInput.Split(":");
            int[] timeInt = new int[2];
            timeInt[0] = Convert.ToInt32(time[0]);
            timeInt[1] = Convert.ToInt32(time[1]);
            return timeInt;
        }
        private string ValueAtMinutes(decimal one, decimal two, int minutes)
        {
            return ((two - one) / 60 * minutes + one).ToString("F1");   
           
        }
        private bool CheckDayLight(string time, string sunrise, string sunset)
        {
            DateTime dateTime;
            DateTime dateSunrise;
            DateTime dateSunset;

            if (DateTime.TryParseExact(sunrise, "h:mm tt", CultureInfo.InvariantCulture, DateTimeStyles.None, out dateSunrise) != true)
                        MessageBox.Show("Fehlerhafte Sonnenaufgangszeit Konvertierung");

            if (DateTime.TryParseExact(sunset, "h:mm tt", CultureInfo.InvariantCulture, DateTimeStyles.None, out dateSunset) != true)
                             MessageBox.Show("Fehlerhafte Sonnenunterhangszeit Konvertierung");

            if (DateTime.TryParseExact(time, "H:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out dateTime) != true)
                         MessageBox.Show("Fehlerhafte Eingbezeit Konvertierung");

            if (dateTime >= dateSunrise && dateTime < dateSunset)
                return true;
            else
                return false;    
        }
    }
}
