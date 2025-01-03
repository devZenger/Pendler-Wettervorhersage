using System.Windows;



namespace Pendler_Wettervorhersage
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private SearchParameter _hometownInput = new SearchParameter();
        private SearchParameter _workplaceInput = new SearchParameter();

        public MainWindow()
        {
            InitializeComponent();

            var viewModel = new MainViewModel();
            this.DataContext = viewModel;






        }

        private void SaveAndCall_Click(object sender, RoutedEventArgs e)
        {
            MainViewModel viewModel = (MainViewModel)DataContext;

            _hometownInput = viewModel.Search.HometownInput;

            //_hometownInput.SearchLocation = viewModel.Search.HometownInput.SearchLocation;
            //_hometownInput.StartTime = viewModel.Search.HometownInput.StartTime;
            //_hometownInput.EndTime = viewModel.Search.HometownInput.EndTime;

            _workplaceInput.SearchLocation = viewModel.Search.WorkplaceInput.SearchLocation;
            _workplaceInput.StartTime = viewModel.Search.WorkplaceInput.StartTime;
            _workplaceInput.EndTime = viewModel.Search.WorkplaceInput.EndTime;


            SearchInputProcress input = new SearchInputProcress();


            input.CheckSearchInput(_hometownInput, _workplaceInput);

            GetWeatherForecast getForecast = new GetWeatherForecast(viewModel);

            getForecast.MainProcess(_hometownInput, _workplaceInput);

        }




    }

}