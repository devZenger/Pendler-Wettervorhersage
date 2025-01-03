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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Pendler_Wettervorhersage
{
    /// <summary>
    /// Interaktionslogik für SearchInputPanel.xaml
    /// </summary>
    public partial class SearchInputPanel : UserControl
    {
        public SearchInputPanel()
        {
            InitializeComponent();
        }

        private void LocationTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            LocationInput.Text = string.Empty;
        }
    }
}
