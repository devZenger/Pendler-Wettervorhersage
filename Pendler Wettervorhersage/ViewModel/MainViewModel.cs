using Pendler_Wettervorhersage.Service;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;

namespace Pendler_Wettervorhersage
{
    internal class MainViewModel : NotifyPropertyChangedBase
    {
        public ObservableCollection<ForecastReport> HometownPanels { get; set; } // = new ForecastReport[6];
        public ObservableCollection<ForecastReport> WorkplacePanels { get; set; } // = new ForecastReport[6];

        private SearchParameter _hometownInput;
        public SearchParameter HometownInput
        {
            get => _hometownInput;
            set
            {
                if (_hometownInput != value)
                {
                    _hometownInput = value;
                    OnPropertyChanged();

                    if (_hometownInput != null)
                        _hometownInput.PropertyChanged -= HometownInput_PropertyChanged;

                    if (_hometownInput != null)
                        _hometownInput.PropertyChanged += HometownInput_PropertyChanged;
                }
            }
        }
        private void HometownInput_PropertyChanged(object? sender, PropertyChangedEventArgs e) 
        {
            if (e.PropertyName == nameof(HometownInput.SearchLocation) || e.PropertyName == nameof(HometownInput.StartTime) || e.PropertyName == nameof(HometownInput.EndTime))
            { SaveAndGetWeatherCommand?.RaiseCanExecuteChanged(); }
        }

        private SearchParameter _workplaceInput;
        public SearchParameter WorkplaceInput
        {
            get => _workplaceInput;
            set
            {
                if (_workplaceInput != value)
                {
                    _workplaceInput = value;
                    OnPropertyChanged();
        
                    if (_workplaceInput != null)
                        _workplaceInput.PropertyChanged -= WorkplaceInput_PropertyChanged;

                    if (_workplaceInput != null)
                        _workplaceInput.PropertyChanged += WorkplaceInput_PropertyChanged;
                }
            }
        }
        private void WorkplaceInput_PropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(WorkplaceInput.SearchLocation) || e.PropertyName == nameof(WorkplaceInput.StartTime) || e.PropertyName == nameof(WorkplaceInput.EndTime))
            { SaveAndGetWeatherCommand?.RaiseCanExecuteChanged(); }
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

            HometownInput = new SearchParameter();
            HometownInput.SearchLocation = "Ingolstadt";
            HometownInput.StartTime = "7:00";
            HometownInput.EndTime = "16:00";

            WorkplaceInput = new SearchParameter();

            Expander = new DelegateCommand<bool?>(UseExpander);

            this.SaveAndGetWeatherCommand = new DelegateNoParameter(SaveAndGetWeatherReports, canSaveInput);
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


        




        //Expander 
        private int _columWidth = 260;
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

            else ColumWidth = 260;
        }


        // Save and get weather reports
        public DelegateNoParameter SaveAndGetWeatherCommand { get; set; }

        public void SaveAndGetWeatherReports()
        {
            SaveInput();

            GetWeatherReports();
        }


        internal void SaveInput()
        {
            SettingsManager settingsManager = new SettingsManager();

            settingsManager.updateHometown(HometownInput); 

            settingsManager.updateWorkplace(WorkplaceInput);

        }

        public bool canSaveInput()
        {
            SearchInputCheck searchInputCheck = new SearchInputCheck();

            bool testHometowen = searchInputCheck.CheckInput(HometownInput);

            bool testWorkplace = searchInputCheck.CheckInput(WorkplaceInput);

            Console.WriteLine($"{testHometowen} + {testWorkplace}");

            if (testHometowen && testWorkplace)
                return true;
            else
                return false;
        }

        public void GetWeatherReports()
        {
            GetWeatherForecast getWeatherForecast = new GetWeatherForecast();

            // Hometown part
            List<ForecastReport> forecastReports = getWeatherForecast.Process(HometownInput, true);

            HometownPanels.Clear();
            foreach (ForecastReport forecastReport in forecastReports)
            {
                HometownPanels.Add(forecastReport);
            }

            HometownInput.Name = forecastReports[0].Name;
            HometownInput.Region = forecastReports[0].Region;
            HometownInput.Country = forecastReports[0].Country;

            // Workplace part
            forecastReports.Clear();

            forecastReports = getWeatherForecast.Process(WorkplaceInput, true);

            WorkplacePanels.Clear();
            foreach (ForecastReport forecastReport in forecastReports)
            {
                WorkplacePanels.Add(forecastReport);
            }
            WorkplaceInput.Name = forecastReports[0].Name;
            WorkplaceInput.Region = forecastReports[0].Region;
            WorkplaceInput.Country = forecastReports[0].Country;


        }




        /*
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
        }*/







    }
}
