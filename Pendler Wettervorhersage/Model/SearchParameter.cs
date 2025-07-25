﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pendler_Wettervorhersage
{
    internal class SearchParameter : NotifyPropertyChangedBase
    {
        private string _searchLocation = string.Empty;
        public string SearchLocation
        {
            get => _searchLocation;
            set
            {
                if (_searchLocation != value)
                {
                    _searchLocation = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _startTime = string.Empty;
        public string StartTime
        {
            get => _startTime;
            set
            {
                if (_startTime != value)
                {
                    _startTime = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _endTime = string.Empty;
        public string EndTime
        {
            get => _endTime;
            set
            {
                if (_endTime != value)
                {
                    _endTime = value;
                    OnPropertyChanged();
                }
            }
        }


        // Location
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

        //Error message
        private string _errorMessage = string.Empty;
        public string ErrorMessage
        {
            get => _errorMessage;
            set
            {
                if (value != _errorMessage)
                {
                    _errorMessage = value;
                    OnPropertyChanged();
                }
            }
        }














    }
}
