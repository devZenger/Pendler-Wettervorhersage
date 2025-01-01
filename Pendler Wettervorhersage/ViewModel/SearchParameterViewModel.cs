using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Pendler_Wettervorhersage
{
    internal class SearchParameterViewModel : NotifyPropertyChangedBase
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








        
    }
}
