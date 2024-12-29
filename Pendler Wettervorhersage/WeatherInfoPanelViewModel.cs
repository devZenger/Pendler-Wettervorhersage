using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pendler_Wettervorhersage
{
    public class WeatherInfoPanelViewModel
    {
        public string TitleDay { get; set; } = "Heute";
        public string ApiWeatherDiscription { get; set; } = "sonnig";
        public string TemperaturC { get; set; } = "23,5°C";
        public string WindChillTempC { get; set; } = "-5,2°C";
        public string AddtionalInformation { get; set; } = "Wind aus Norden";
    }
}
