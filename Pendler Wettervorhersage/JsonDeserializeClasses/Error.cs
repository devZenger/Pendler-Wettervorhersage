using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pendler_Wettervorhersage
{
    internal class Error
    {
        [JsonProperty("code")]
        public int Code { get; set; } = 0;
        [JsonProperty("message")]
        public string Message { get; set; } = string.Empty;
    }
}
