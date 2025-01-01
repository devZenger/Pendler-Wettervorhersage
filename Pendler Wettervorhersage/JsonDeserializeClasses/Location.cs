using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pendler_Wettervorhersage
{
    internal class Location
    {
        [JsonProperty("name")]
        string Name { get; set; } = string.Empty;
    }
}
