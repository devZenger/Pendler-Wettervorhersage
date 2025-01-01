using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;

namespace Pendler_Wettervorhersage
{
    internal class MainViewModel : NotifyPropertyChangedBase
    {
        public WeatherInfoPanelViewModel[] HometownPanels { get; set; } = new WeatherInfoPanelViewModel[6];
        public WeatherInfoPanelViewModel[] WorkplacePanels { get; set; } = new WeatherInfoPanelViewModel[6];

        private SearchInputViewModel _search;
        public SearchInputViewModel Search
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
            for (int i = 0; i < WorkplacePanels.Length; i++)
            {
                HometownPanels[i] = new WeatherInfoPanelViewModel();
                WorkplacePanels[i] = new WeatherInfoPanelViewModel();
                
            }

            Search = new SearchInputViewModel();
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
        




    }
}
