using System.Collections.ObjectModel;
using System.Windows;

namespace Pendler_Wettervorhersage
{
    internal class MainViewModel : NotifyPropertyChangedBase
    {

        public ObservableCollection<ForecastReport> HometownPanels { get; set; } // = new ForecastReport[6];
        public ObservableCollection<ForecastReport> WorkplacePanels { get; set; } // = new ForecastReport[6];

        private SearchInput _search;
        public SearchInput Search
        {
            get => _search;
            set
            {
                if (_search != value)
                {
                    _search = value;
                    OnPropertyChanged();
                }
            }
        }


        public MainViewModel()
        {
            HometownPanels = new ObservableCollection<ForecastReport>();
            WorkplacePanels = new ObservableCollection<ForecastReport>();
            for (int i = 0; i < 6; i++)
            {
                HometownPanels.Add(new ForecastReport());
                WorkplacePanels.Add(new ForecastReport());

            }

            Search = new SearchInput();

            Expander = new DelegateCommand<bool?>(UseExpander);
        }


        public void Errormessage(ErrorMessages messageErrors)
        {
            int messageNumber;

            for (messageNumber = 0; messageNumber < messageErrors.MessageErrors.Count; messageNumber++)
            {
                if (messageErrors.MessageErrors[messageNumber].IsError == true)
                    break;
            }

            MessageBox.Show($"{messageErrors.MessageErrors[messageNumber].Message}", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
        }


        public void UpdateHometownForecast(List<ForecastReport> forecastReports)
        {
            HometownPanels.Clear();
            foreach (ForecastReport forecastReport in forecastReports)
            {
                HometownPanels.Add(forecastReport);
            }
        }

        public void UpdateWorkplaceForecast(List<ForecastReport> forecastReports)
        {
            WorkplacePanels.Clear();
            foreach (ForecastReport forecastReport in forecastReports)
            {
                WorkplacePanels.Add(forecastReport);
            }
        }




        //Expander 
        private int _columWidth = 200;
        public int ColumWidth
        {
            get => _columWidth;
            set { if (_columWidth != value) { _columWidth = value; OnPropertyChanged(); } }
        }
        public DelegateCommand<bool?> Expander { get;}

        public void UseExpander(bool? status)
        {
            if (status.HasValue)
                if (status == true)
                    ColumWidth = 0;

            else ColumWidth = 200;


        }









    }
}
