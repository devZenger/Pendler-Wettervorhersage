using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Pendler_Wettervorhersage
{
    internal class SearchInput : NotifyPropertyChangedBase
    { 

        private SearchParameter? _hometownInput;

        public SearchInput()
        {
            HometownInput = new SearchParameter();

            HometownInput.SearchLocation = "Ort eingeben";
            HometownInput.StartTime = "7:00";
            HometownInput.EndTime = "18:00";

            WorkplaceInput = new SearchParameter();

            WorkplaceInput.SearchLocation = "München";
            WorkplaceInput.StartTime = "8:00";
            WorkplaceInput.EndTime = "17:00";
        }




        public SearchParameter HometownInput
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

        private SearchParameter _workplaceInput;

        public SearchParameter WorkplaceInput
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

       

    
    }
}
