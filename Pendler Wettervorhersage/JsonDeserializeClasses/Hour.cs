using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pendler_Wettervorhersage
{
    internal class Hour
    {
        [JsonProperty("time")]
        public string Time { get; set; } = string.Empty;
        [JsonProperty("temp_c")]
        public decimal TempC { get; set; }
        public Condition Condition { get; set; }
        [JsonProperty("feelslike_c")]
        public decimal FeelsLikeC { get; set; }
        [JsonProperty("chance_of_rain")]
        public int ChanceOfRain { get; set; }
        [JsonProperty("chance_of_snow")]
        public int ChanceOfSnow { get; set; }
    }
}
