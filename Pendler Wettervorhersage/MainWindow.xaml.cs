using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using SharpVectors;



namespace Pendler_Wettervorhersage
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public WeatherInfoPanelViewModel PanelData { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            //GetWeatherForcast test = new GetWeatherForcast();

            //test.UseWeatherApi("München Deutschland");


            string svgPath = "pack://application:,,,/Icons/Day/1.svg";

            PanelData = new WeatherInfoPanelViewModel();

            DataContext = this;




            SvgImage.Source = new Uri(svgPath);






            /*try
            {ResizeMode="NoResize"
                string test = "fdasfd";

                int number = int.Parse(test); 
                // Weitere Logik hier
                 }
            catch (FormatException ex) 
            { 
                MessageBox.Show("Ungültige Eingabe! Bitte geben Sie eine Zahl ein.", "Eingabefehler", MessageBoxButton.OK, MessageBoxImage.Error); 
            }/*/

        }



    }

}