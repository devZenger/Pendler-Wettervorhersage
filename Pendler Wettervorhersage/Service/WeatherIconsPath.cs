using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Media.Media3D;

namespace Pendler_Wettervorhersage.Service
{
    internal class WeatherIconsPath
    {

        public string getIconPath(int code) 
        {
            return code switch {

                // Sunny and cloudy
                1000 => "/Icons/Weather/clear-day.svg",
                1003 => "Icons/Weather/partly-cloudy-day.svg",
                1006 => "Icons/Weather/overcast-day.svg",
                1009 => "Icons/Weather/overcast.svg",

                //Thunder
                1087 => "/Icons/Weather/thunderstorms-day.svg",
                1273 or 1276 => "/Icons/Weather/thunderstorms-day-rain.svg",
                1279 or 1282 or 1117 => "/Icons/Weather/thunderstorms-day-snow.svg",
                
                //Fog
                1030 => "/Icons/Weather/haze-day.svg",
                1035 or 1147 => "Icons/Weather/fog-day.scg",

                //Rain
                1195 => "/Icons/Weather/rain.svg",
                1186 or 1189 or 1192 => "/Icons/Weather/partly-cloudy-day-rain.scg",
                1063 or 1180 or 1183 or 1240 => "/Icons/Weather/partly-cloudy-day-drizzle.svg",

                //Snow 
                1066 or 1114 or 1210 or 1213 or 1216 or 1219 or 1255 or 1258 => "/Icons/Weather/partly-cloudy-day-snow.svg",
                1222 or 1225 => "/Icons/Weather/snow.svg",



                //Snow and rain
                1069 or 1204 or 1249 => "/Icons/Weather/partly-cloudy-day-sleet.svg",
                1207 or 1252 => "/Icons/Weather/sleet.svg",

                //Ice and frozen rains
                1072 or 1150 or 1153 or 1168 or 1198 => "/Icons/Weather/partly-cloudy-day-sleet.svg", 
                1237 or 1261 => "/Icons/Weather/partly-cloudy-day-hail.svg",
                1264 => "/Icons/Weather/sleet.svg",
                1201 or 1171 => "/Icons/Weather/partly-cloudy-day-sleet.svg",

                _ => "Icons/Weather/partly-cloudy-day.svg"

            };

        }
    }
}
