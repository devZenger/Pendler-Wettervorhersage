
using Pendler_Wettervorhersage.Service;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net.Sockets;
using System.Windows;

namespace Pendler_Wettervorhersage
{
    internal class MainViewModel : NotifyPropertyChangedBase
    {
        public ObservableCollection<ForecastReport> HometownPanels { get; set; }
        public ObservableCollection<ForecastReport> WorkplacePanels { get; set; }

        private SearchParameter? _hometownInput;
        public SearchParameter HometownInput
        {
            get => _hometownInput!;
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

        private SearchParameter? _workplaceInput;
        public SearchParameter WorkplaceInput
        {
            get => _workplaceInput!;
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
        public ApiKey ApiKeyModel { get; }

        public DelegateNoParameter SaveCommand { get; }




        internal MainViewModel()
        {
            ForecastReport Info = new ForecastReport();
            Info.TitleDay = "Heute";
            Info.ApiWeatherDiscription = "Klar";
            Info.TemperaturC = "24°C";
            Info.FeelsLikeTempC = "19°C";
            Info.AddtionalInformation = "Regenw.: 12%";


            HometownPanels = new ObservableCollection<ForecastReport>();
            DefaultHometown();
            WorkplacePanels = new ObservableCollection<ForecastReport>();
            DefaultWorkplace();

            HometownInput = new SearchParameter();
            WorkplaceInput = new SearchParameter();

            ApiKeyModel = new ApiKey
            {
                StoredApiKey = SettingsService.Current.ApiKey
            };

            this.SaveCommand = new DelegateNoParameter(SaveApiKey);

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
        private int _columWidthBlue = 5;
        public int ColumWidthBlue
        {
            get => _columWidthBlue;
            set { if (_columWidthBlue != value) { _columWidthBlue = value; OnPropertyChanged(); } }
        }
        public DelegateCommand<bool?> ToggleCollapse { get; }

        private void UseCollapse(bool? status)
        {
            if (status.HasValue)
                if (status == true)
                {
                    ColumWidth = 0;
                    ColumWidthBlue = 0;
                    Application.Current.MainWindow.Width = 540;
                }
                else
                {
                    ColumWidth = 200;
                    ColumWidthBlue = 5;
                    Application.Current.MainWindow.Width = 780;
                }
        }


        // Save and get weather reports
        public DelegateNoParameter SaveAndGetWeatherCommand { get; }
        internal void SaveAndGetWeatherReports()
        {
            SaveInput();

            GetWeatherReports();
        }


        private void SaveInput()
        {
            if (SettingsService.Current.HometownLocation != HometownInput.SearchLocation)
            {
                SettingsService.Current.HometownLocation = HometownInput.SearchLocation;
                SettingsService.Save();
            }
            if (SettingsService.Current.HometownStartTime != HometownInput.StartTime)
            {
                SettingsService.Current.HometownStartTime = HometownInput.StartTime;
                SettingsService.Save();
            }
            if (SettingsService.Current.HometownEndTime != HometownInput.EndTime)
            {
                SettingsService.Current.HometownEndTime = HometownInput.EndTime;
                SettingsService.Save();
            }

            if (SettingsService.Current.WorkplaceLocation != WorkplaceInput.SearchLocation)
            {
                SettingsService.Current.WorkplaceLocation = WorkplaceInput.SearchLocation;
                SettingsService.Save();
            }
            if (SettingsService.Current.WorkplaceStartTime != WorkplaceInput.StartTime)
            {
                SettingsService.Current.WorkplaceStartTime = WorkplaceInput.StartTime;
                SettingsService.Save();
            }
            if (SettingsService.Current.WorkplaceEndTime != WorkplaceInput.EndTime)
            {
                SettingsService.Current.WorkplaceEndTime = WorkplaceInput.EndTime;
                SettingsService.Save();
            }
        }

        private bool canSaveInput()
        {
            SearchInputCheck searchInputCheck = new SearchInputCheck();

            bool testHometowen = searchInputCheck.CheckInput(HometownInput);
            bool testWorkplace = searchInputCheck.CheckInput(WorkplaceInput);

            if (testHometowen && testWorkplace)
                return true;
            else
                return false;
        }

        private void GetWeatherReports()
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

                HometownInput.ErrorMessage = "";

            }
            catch (Exception ex)
            {
                DefaultHometown();

                HometownInput.ErrorMessage = ErrorHandling(ex);
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

                WorkplaceInput.ErrorMessage = "";
            }
            catch (Exception ex)
            {
                DefaultWorkplace();

                WorkplaceInput.ErrorMessage = ErrorHandling(ex);
            }
        }

        //Programm start
        internal void Startapp()
        {
            WorkplaceInput.SearchLocation = SettingsService.Current.WorkplaceLocation;
            WorkplaceInput.StartTime = SettingsService.Current.WorkplaceStartTime;
            WorkplaceInput.EndTime = SettingsService.Current.WorkplaceEndTime;

            HometownInput.SearchLocation = SettingsService.Current.HometownLocation;
            HometownInput.StartTime = SettingsService.Current.HometownStartTime;
            HometownInput.EndTime = SettingsService.Current.HometownEndTime;

            GetWeatherReports();

            if (SettingsService.Current.FirstStart == true)
            {
                StartInfo();
                SettingsService.Current.FirstStart = false;
            }
        }

        // InfoWindow
        public DelegateNoParameter InfoWindow { get; }

        private void StartInfo()
        {
            var infoWindowInstance = new Info();
            infoWindowInstance.Show();
        }

        private void SaveApiKey()
        {
            SettingsService.Current.ApiKey = ApiKeyModel.StoredApiKey;
        }


        private void DefaultHometown()
        {
            DefaultForecastReports defaultReports = new DefaultForecastReports();

            HometownPanels.Clear();
            foreach (ForecastReport forecastReport in defaultReports.ForecastsHome)
            {
                HometownPanels.Add(forecastReport);
            }

        }
        private void DefaultWorkplace()
        {
            DefaultForecastReports defaultReports = new DefaultForecastReports();

            WorkplacePanels.Clear();
            foreach (ForecastReport forecastReport in defaultReports.ForecastsWork)
            {
                WorkplacePanels.Add(forecastReport);
            }
        }

        private string ErrorHandling(Exception ex)
        {
            if (ex.Message.Contains("Host") || ex.Message.Contains("unbekannt") || ex.InnerException is SocketException)
                return "Verbindungsfehler: Internet prüfen.";

            else if (ex.Message.Contains("401") || ex.Message.Contains("API key is invalid"))
                return "Ungültiger API-Key.";
            else
                return "Unbekannter Fehler.";

        }
    }
}
