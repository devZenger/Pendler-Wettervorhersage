using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Pendler_Wettervorhersage
{
    internal class MainViewModel : INotifyPropertyChanged
    {
        public WeatherInfoPanelViewModel[] HometownPanels { get; set; } = new WeatherInfoPanelViewModel[6];
        public WeatherInfoPanelViewModel[] WorkplacePanels { get; set; } = new WeatherInfoPanelViewModel[6];

        private UserInputViewModel _userInput;
        public UserInputViewModel UserInput
        {
            get => _userInput;
            set
            {
                if (_userInput != value)
                {
                    _userInput = value;
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

            WorkplacePanels[0].TitleDay = "Heute";

        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }




    }
}
