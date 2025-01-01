using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Pendler_Wettervorhersage
{
    internal class SearchInputViewModel : INotifyPropertyChanged
    {
        private SearchParameterViewModel? _hometownInput;

        public SearchParameterViewModel HometownInput
        {
            get => _hometownInput;
            set
            {
                if (_hometownInput != value)
                {
                    _hometownInput = value;
                    OnPropertyChanged();
                }
            }
        }

        private SearchParameterViewModel _workplaceInput;

        public SearchParameterViewModel WorkplaceInput
        {
            get => _workplaceInput;
            set
            {
                if (_workplaceInput != value)
                {
                    _workplaceInput = value;
                    OnPropertyChanged();
                }
            }
        }

        public SearchInputViewModel()
        {
            HometownInput = new SearchParameterViewModel();

            HometownInput.SearchLocation = "Ort eingeben";
            HometownInput.StartTime = "7:00";
            HometownInput.EndTime = "18:00";

            WorkplaceInput = new SearchParameterViewModel();

            WorkplaceInput.SearchLocation = "München";
            WorkplaceInput.StartTime = "8:00";
            WorkplaceInput.EndTime = "17:00";
        }


        public event PropertyChangedEventHandler? PropertyChanged;

        public virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
