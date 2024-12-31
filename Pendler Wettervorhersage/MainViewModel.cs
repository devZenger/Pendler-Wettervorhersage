using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Pendler_Wettervorhersage;
using System.Runtime.CompilerServices;

namespace Pendler_Wettervorhersage
{
    internal class MainViewModel // : INotifyPropertyChanged
    {

        public WeatherInfoPanelViewModel[] WorkplacePanels { get; set; } = new WeatherInfoPanelViewModel[6]; 


       

        public MainViewModel()
        {
            for (int i = 0; i < WorkplacePanels.Length; i++)
            { WorkplacePanels[i] = new WeatherInfoPanelViewModel(); }

            WorkplacePanels[0].TitleDay = "Heute";

        }

        public event PropertyChangedEventHandler? PropertyChanged;

        /*
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
         {
             PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

         }
        */

        
    }
}
