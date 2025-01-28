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
                if (_titleDay != value)
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
                if (_apiWeatherDiscription != value)
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
                if (_temperaturC != value)
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
                if (_feelsLikeTempC != value)
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
                if (_iconPath != value)
                {
                    _iconPath = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _addtionalInformation = "Regenw.: 67%";

        public string AddtionalInformation
        {
            get => _addtionalInformation;
            set
            {
                if (_addtionalInformation != value)
                {
                    _addtionalInformation = value;
                    OnPropertyChanged();
                }
            }
        }

        //Location
        private string _name = string.Empty;
        public string Name
        {
            get => _name;
            set
            {
                if (_name != value)
                {
                    _name = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _region = string.Empty;
        public string Region
        {
            get => _region;
            set
            {
                if (_region != value)
                {
                    _region = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _country = string.Empty;
        public string Country
        {
            get => _country;
            set
            {
                if (_country != value)
                {
                    _country = value;
                    OnPropertyChanged();
                }
            }
        }

    }
}



