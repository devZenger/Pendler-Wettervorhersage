﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pendler_Wettervorhersage
{
    internal class Forecast
    {
        [JsonProperty("forecastday")]
        public List<Forecastday> Forecastdays { get; set; } = new List<Forecastday>();
    }
}
