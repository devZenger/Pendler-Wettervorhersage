using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pendler_Wettervorhersage
{
    internal class Condition
    {
        [JsonProperty("text")]
        public string Text {  get; set; } = string.Empty;
        [JsonProperty("icon")]
        public string Icon { get; set; } = string.Empty;
    }
}
