using System.Windows;



namespace Pendler_Wettervorhersage
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            Properties.Settings.Default.Reset();
            InitializeComponent();

            var viewModel = new MainViewModel();
            this.DataContext = viewModel;






        }

       

       
    }

}