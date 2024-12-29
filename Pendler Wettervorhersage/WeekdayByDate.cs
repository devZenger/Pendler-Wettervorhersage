using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pendler_Wettervorhersage
{
    class WeekdayByDate
    {
        // Time from WeatherApi = "2024-12-29 01:00"
        public string GetWeekday(string time)
        {
            string[] times = time.Split();

            string[] date = times[0].Split('-');

            int year = int.Parse(date[0]);
            int month = int.Parse(date[1]);
            int day = int.Parse(date[2]);

            DateTime dateOfWeekday = new DateTime(year, month, day);

            return dateOfWeekday.DayOfWeek.ToString();

        }

    }
}
