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
        //public string Wind_kph { get; set; }
        //public string Wind_dir { get; set; }

        // public double Pricip_mm { get; set; }

        [JsonProperty("feelslike_c")]
        public decimal FeelsLikeC { get; set; }

        [JsonProperty("will_it_rain")]
        public int WillItRain { get; set; }



    }
}
