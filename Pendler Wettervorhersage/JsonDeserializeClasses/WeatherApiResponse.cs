using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pendler_Wettervorhersage
{
    internal class WeatherApiResponse
    {
        [JsonProperty("location")]
        public Location Location { get; set; } = new Location();

        [JsonProperty("forecast")]
        public Forecast Forecast {get; set; } = new Forecast();
        [JsonProperty("error")]
        public Error Error { get; set; } = new Error();
    }
}
