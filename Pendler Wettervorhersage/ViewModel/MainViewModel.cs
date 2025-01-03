using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;

namespace Pendler_Wettervorhersage
{
    internal class MainViewModel : NotifyPropertyChangedBase
    {
        public ForecastReport[] HometownPanels { get; set; } = new ForecastReport[6];
        public ForecastReport[] WorkplacePanels { get; set; } = new ForecastReport[6];

        private SearchInput _search;
        public SearchInput Search
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
                HometownPanels[i] = new ForecastReport();
                WorkplacePanels[i] = new ForecastReport(); 
            }

            Search = new SearchInput();
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
