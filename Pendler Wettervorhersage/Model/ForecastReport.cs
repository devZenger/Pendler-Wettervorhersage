namespace Pendler_Wettervorhersage
{ 
    internal class ForecastReport : NotifyPropertyChangedBase
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

        
        private string _feelsLikeTempC = "-5,2°C";
        public string FeelsLikeTempC
        {
            get => _feelsLikeTempC;
            set
            {
                if (_feelsLikeTempC != value) ;
                {
                    _feelsLikeTempC = value;
                    OnPropertyChanged();
                }
            }
        }


        private string _iconPath = string.Empty;

        public string IconPath
        {
            get => _iconPath;
            set
            {
                if (_iconPath != value) ;
                {
                    _iconPath = value;
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



        public void UpdateAll(string title, string discription, string tempC, string windChillC, string addInformation)
        {
            _titleDay = title;
            _apiWeatherDiscription = discription;
            _temperaturC = tempC;
          
            _addtionalInformation = addInformation;

            OnPropertyChanged();
        }


    }



}



