using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Pendler_Wettervorhersage
{
    internal class Forecastday
    {
        [JsonProperty("date")]
        public string Date { get; set; } = string.Empty;
        [JsonProperty("hour")]
        public List<Hour> Hours { get; set; } = new List<Hour>();
    }
}
