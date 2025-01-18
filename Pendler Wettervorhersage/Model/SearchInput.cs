using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Pendler_Wettervorhersage
{
    internal class SearchInput : NotifyPropertyChangedBase
    { 

        

        public SearchInput()
        {
            //HometownInput = new SearchParameter();

            //HometownInput.SearchLocation = "Ort eingeben";
            //HometownInput.StartTime = "7:00";
            //HometownInput.EndTime = "18:00";

           // WorkplaceInput = new SearchParameter();

            
        }

        private SearchParameter _hometownInput;
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
