using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Pendler_Wettervorhersage
{
    internal class MainViewModel : INotifyPropertyChanged
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

        public event PropertyChangedEventHandler? PropertyChanged;

        public virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }




    }
}
