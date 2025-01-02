namespace Pendler_Wettervorhersage
{
    internal class ForecastData
    {
        public ForecastReport Forecast { get; set; }

        public ForecastData(ForecastReport forecast) 
        {
            Forecast = forecast;
        }


        internal class ForecastReport
        {
            public string Time { get; set; } = string.Empty;
            public string TempC { get; set; } = string.Empty;
            public string Discription { get; set; } = string.Empty;
            public string Icon { get; set; } = string.Empty;
            public string FeelsLikeC { get; set; } = string.Empty;
            public string WillItRain { get; set; } = string.Empty;

        }

    }
    
}



