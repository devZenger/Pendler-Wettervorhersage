using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pendler_Wettervorhersage
{
    internal class MainForecastDataProcess
    {

        public List<ForecastData> ProcessData(SearchParameter searchInput)
        {

            ForecastDataProcess dailyProcess = new ForecastDataProcess();

            List<ForecastData> forecastInfosForPanels = new List<ForecastData>();

            for (int i = 0; i < 3;)
            {
                for (int j = 0; j < 6; j++)
                {
                    forecastInfosForPanels.Add(forecastInfosForPanels[j]);

                    if (j == 0 || j == 2 || j == 4)
                        dailyProcess.SingleDayForecast(searchInput.SearchLocation, searchInput.StartTime, i);
                    else
                        dailyProcess.SingleDayForecast(searchInput.SearchLocation, searchInput.EndTime, i);
                }
            }

            return forecastInfosForPanels;

        }
    }
}
