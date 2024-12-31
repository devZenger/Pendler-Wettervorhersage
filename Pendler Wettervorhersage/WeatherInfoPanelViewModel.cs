using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Pendler_Wettervorhersage
{
    internal class WeatherInfoPanelViewModel : INotifyPropertyChanged
    {
        private string _titleDay = "Heute";
        public string TitleDay
        {
            get => _titleDay;
            set
            {
                if (_titleDay != value) ;
                {
                    _titleDay = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _apiWeatherDiscription = "sonnig";
        public string ApiWeatherDiscription
        {
            get => _apiWeatherDiscription;
            set
            {
                if (_apiWeatherDiscription != value) ;
                {
                    _apiWeatherDiscription = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _temperaturC = "23,5°C";
        public string TemperaturC 
        {
            get => _temperaturC;
            set
            {
                if (_temperaturC != value) ;
                {
                    _temperaturC = value;
                    OnPropertyChanged();
                }
            }
        }
        private string _windChillTempC = "-5,2°C";
        public string WindChillTempC
        {
            get => _windChillTempC;
            set
            {
                if (_windChillTempC != value) ;
                {
                    _windChillTempC = value;
                    OnPropertyChanged();
                }
            }
        }
        
        private string _addtionalInformation = "Wind aus Norden";

        public string AddtionalInformation
        {
            get => _addtionalInformation;
            set
            {
                if (_addtionalInformation != value) ;
                {
                    _addtionalInformation = value;
                    OnPropertyChanged();
                }
            }
        }



        public void UpdateAll(string title)
        {
            TitleDay = title;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(null));
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public virtual void OnPropertyChanged([CallerMemberName] string propertyName= "") 
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


           

        



    }
}
