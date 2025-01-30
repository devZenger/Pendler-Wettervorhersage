using Pendler_Wettervorhersage.Service;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;

namespace Pendler_Wettervorhersage
{
    internal class MainViewModel : NotifyPropertyChangedBase
    {
        public ObservableCollection<ForecastReport> HometownPanels { get; set; }
        public ObservableCollection<ForecastReport> WorkplacePanels { get; set; }

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
            ForecastReport Info = new ForecastReport();
            Info.TitleDay = "Heute";
            Info.ApiWeatherDiscription = "Klar";
            Info.TemperaturC = "24°C";
            Info.FeelsLikeTempC = "19°C";
            Info.AddtionalInformation = "Regenw.: 12%";


            HometownPanels = new ObservableCollection<ForecastReport>();
            WorkplacePanels = new ObservableCollection<ForecastReport>();
            for (int i = 0; i < 6; i++)
            {
                HometownPanels.Add(new ForecastReport());
                WorkplacePanels.Add(new ForecastReport());

            }

            HometownInput = new SearchParameter();
            WorkplaceInput = new SearchParameter();

            ToggleCollapse = new DelegateCommand<bool?>(UseCollapse);

            this.SaveAndGetWeatherCommand = new DelegateNoParameter(SaveAndGetWeatherReports, canSaveInput);
            this.InfoWindow = new DelegateNoParameter(StartInfo);

            Startapp();

        }

        //Collapse search input
        private int _columWidth = 200;
        public int ColumWidth
        {
            get => _columWidth;
            set { if (_columWidth != value) { _columWidth = value; OnPropertyChanged(); } }
        }
        public DelegateCommand<bool?> ToggleCollapse { get;}

        public void UseCollapse(bool? status)
        {
            if (status.HasValue)
                if (status == true)
                {
                    ColumWidth = 0;
                    Application.Current.MainWindow.Width = 560;
                }
                else 
                { 
                    ColumWidth = 200;
                    Application.Current.MainWindow.Width = 760;
                }
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

            settingsManager.UpdateHometown(HometownInput); 
            settingsManager.UpdateWorkplace(WorkplaceInput);
        }

        public bool canSaveInput()
        {
            SearchInputCheck searchInputCheck = new SearchInputCheck();

            bool testHometowen = searchInputCheck.CheckInput(HometownInput);
            bool testWorkplace = searchInputCheck.CheckInput(WorkplaceInput);

            if (testHometowen && testWorkplace)
                return true;
            else
                return false;
        }

        public void GetWeatherReports()
        {
            GetWeatherForecast getWeatherForecast = new GetWeatherForecast();

            List<ForecastReport> forecastReports = new List<ForecastReport>();
            // Hometown part
            try
            {
                forecastReports = getWeatherForecast.Process(HometownInput);

                HometownPanels.Clear();
                foreach (ForecastReport forecastReport in forecastReports)
                {
                    HometownPanels.Add(forecastReport);
                }
                HometownInput.Name = forecastReports[0].Name;
                HometownInput.Region = forecastReports[0].Region;
                HometownInput.Country = forecastReports[0].Country;
            }
            catch (Exception ex)
            {
                HometownInput.ErrorMessage = ex.Message;
            }
            // Workplace part
            forecastReports.Clear();
            try
            {
                forecastReports = getWeatherForecast.Process(WorkplaceInput);

                WorkplacePanels.Clear();
                foreach (ForecastReport forecastReport in forecastReports)
                {
                    WorkplacePanels.Add(forecastReport);
                }
                WorkplaceInput.Name = forecastReports[0].Name;
                WorkplaceInput.Region = forecastReports[0].Region;
                WorkplaceInput.Country = forecastReports[0].Country;
            }
            catch (Exception ex)
            {
                WorkplaceInput.ErrorMessage = ex.Message;
            }
        }

        //Programm start
        internal void Startapp()
        {
            SettingsManager settingsManager = new SettingsManager();

            //if (settingsManager.FirstStart == true)
            //{
            //settingsManager.FirstStart = false;

                WorkplaceInput.SearchLocation = settingsManager.WorkplaceLocation;
                WorkplaceInput.StartTime = settingsManager.WorkplaceSartTime;
                WorkplaceInput.EndTime = settingsManager.WorkplaceEndTime;

            
                HometownInput.SearchLocation = settingsManager.HometownLocation;
           
                HometownInput.StartTime = settingsManager.HometownSartTime;
                HometownInput.EndTime = settingsManager.HometownEndTime;

                GetWeatherReports();


            //}
        }

        // InfoWindow
        public DelegateNoParameter InfoWindow { get; }

        public void StartInfo()
        {
            var InfoWindow = new Info();
            InfoWindow.Show();
        }



    }
}
