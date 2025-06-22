namespace Pendler_Wettervorhersage
{
    internal class DefaultForecastReports
    {
        public List<ForecastReport> ForecastsHome { get; }
        public List<ForecastReport> ForecastsWork { get; }

        public DefaultForecastReports()
        {
            ForecastsHome = new List<ForecastReport>
            {
                new ForecastReport {TitleDay = "Heute", ApiWeatherDiscription = "Sonnig", TemperaturC="24°C", FeelsLikeTempC="26°C", IconPath="/Icons/Weather/clear-day.svg", AddtionalInformation="" },
                new ForecastReport {TitleDay = "Heute", ApiWeatherDiscription = "Klar", TemperaturC="18°C", FeelsLikeTempC="17°C", IconPath="/Icons/WeatherNight/clear-night.svg", AddtionalInformation="" },

                new ForecastReport {TitleDay = "Morgen", ApiWeatherDiscription = "leicht bewölkt", TemperaturC="19°C", FeelsLikeTempC="21°C", IconPath="/Icons/Weather/partly-cloudy-day.svg", AddtionalInformation="" },
                new ForecastReport {TitleDay = "Morgen", ApiWeatherDiscription = "bedeckt", TemperaturC="12°C", FeelsLikeTempC="10°C", IconPath="/Icons/WeatherNight/partly-cloudy-night.svg", AddtionalInformation="" },

                new ForecastReport {TitleDay = "1.04.2025", ApiWeatherDiscription = "Schneefall", TemperaturC="-1°C", FeelsLikeTempC="-3°C", IconPath="/Icons/Weather/snow.svg", AddtionalInformation="Schnee.: 100%" },
                new ForecastReport {TitleDay = "1.04.2025", ApiWeatherDiscription = "Schneefall", TemperaturC="-6°C", FeelsLikeTempC="-9°C", IconPath="/Icons/WeatherNight/partly-cloudy-night-snow.svg", AddtionalInformation="Schnee.: 100%" }
            };

            ForecastsWork = new List<ForecastReport>
            {
                new ForecastReport {TitleDay = "Heute", ApiWeatherDiscription = "stellenweise Regenfall", TemperaturC="18°C", FeelsLikeTempC="16°C", IconPath="/Icons/Weather/partly-cloudy-day-rain.svg", AddtionalInformation="Regen.: 60%" },
                new ForecastReport {TitleDay = "Heute", ApiWeatherDiscription = "stellenweise Regenfall", TemperaturC="13°C", FeelsLikeTempC="11°C", IconPath="/Icons/WeatherNight/partly-cloudy-night-rain.svg", AddtionalInformation="Regen.: 50%" },

                new ForecastReport {TitleDay = "Morgen", ApiWeatherDiscription = "Regen", TemperaturC="12°C", FeelsLikeTempC="12°C", IconPath="/Icons/Weather/rain.svg", AddtionalInformation="Regen.: 80%" },
                new ForecastReport {TitleDay = "Morgen", ApiWeatherDiscription = "Regen", TemperaturC="10°C", FeelsLikeTempC="10°C", IconPath="/Icons/WeatherNight/rain.svg", AddtionalInformation="Regen.: 90%" },

                new ForecastReport {TitleDay = "1.04.2025", ApiWeatherDiscription = "starker Regenfall mit Gewitter", TemperaturC="12°C", FeelsLikeTempC="10°C", IconPath="/Icons/Weather/thunderstorms-day.svg", AddtionalInformation="Regen.: 100%" },
                new ForecastReport {TitleDay = "1.04.2025", ApiWeatherDiscription = "starker Regenfall mit Gewitter", TemperaturC="9°C", FeelsLikeTempC="8°C", IconPath="/Icons/WeatherNight/thunderstorms-night.svg", AddtionalInformation="Regen.: 100%" }
            };
        }

    }
}
