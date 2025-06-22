using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Diagnostics;
using System.Windows.Navigation;

namespace Pendler_Wettervorhersage
{
    /// <summary>
    /// Interaktionslogik für Info.xaml
    /// </summary>
    public partial class Info : Window
    {
        public Info()
        {
            InitializeComponent();
            this.Icon = new BitmapImage(new Uri("pack://application:,,,/icons/sunset.ico"));

            var viewModel = new MainViewModel();
            this.DataContext = viewModel;

            


        }
        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri)
            { UseShellExecute = true });
            e.Handled = true;
        }
    }
}
