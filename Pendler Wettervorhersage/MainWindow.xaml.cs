using System.Windows;
using System.Windows.Media.Imaging;



namespace Pendler_Wettervorhersage
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            InitializeComponent();
            this.Icon = new BitmapImage(new Uri("pack://application:,,,/Icons/sunset.ico"));

            var viewModel = new MainViewModel();
            this.DataContext = viewModel;

        }
    }

}