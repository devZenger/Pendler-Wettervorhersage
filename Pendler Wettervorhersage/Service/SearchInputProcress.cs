using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pendler_Wettervorhersage
{
    internal class SearchInputProcress
    {
        //public SearchParameter HometownInput {  get; set; } = new SearchParameter();
        //public SearchParameter WorkplaceInput { get; set; } = new SearchParameter();
       

        public void CheckSearchInput(SearchParameter HometownInput, SearchParameter WorkplaceInput)
        {
            ErrorMessages errorMessages = new ErrorMessages();

            TimeTest checkTimeInput = new TimeTest();

            errorMessages.MessageErrors[0].IsError = !checkTimeInput.CheckTime(HometownInput.StartTime);
            errorMessages.MessageErrors[1].IsError = !checkTimeInput.CheckTime(HometownInput.EndTime);
            errorMessages.MessageErrors[2].IsError = !checkTimeInput.CheckTime(WorkplaceInput.StartTime);
            errorMessages.MessageErrors[3].IsError = !checkTimeInput.CheckTime(WorkplaceInput.EndTime);

            bool checkResult = false;

            bool test2 = (checkTimeInput.CheckTime(HometownInput.StartTime));

            foreach (var inputError in errorMessages.MessageErrors)
            {
                checkResult = inputError.IsError;
                if (checkResult)
                    break;
            }
           

            if (checkResult == true)
            {
                MainViewModel viewModel = new MainViewModel();
                viewModel.Errormessage(errorMessages);
                
            }
            else
            {

            }



        }
    }
}
