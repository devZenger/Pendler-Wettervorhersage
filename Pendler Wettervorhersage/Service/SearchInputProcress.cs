using Pendler_Wettervorhersage.Service;

namespace Pendler_Wettervorhersage
{
    internal class SearchInputProcress
    {
        //public SearchParameter HometownInput {  get; set; } = new SearchParameter();
        //public SearchParameter WorkplaceInput { get; set; } = new SearchParameter();


        public void CheckSearchInput(SearchParameter hometownInput, SearchParameter workplaceInput)
        {
            ErrorMessages errorMessages = new ErrorMessages();

            TimeTest checkTimeInput = new TimeTest();

            errorMessages.MessageErrors[0].IsError = !checkTimeInput.CheckTime(hometownInput.StartTime);
            errorMessages.MessageErrors[1].IsError = !checkTimeInput.CheckTime(hometownInput.EndTime);
            errorMessages.MessageErrors[2].IsError = !checkTimeInput.CheckTime(workplaceInput.StartTime);
            errorMessages.MessageErrors[3].IsError = !checkTimeInput.CheckTime(workplaceInput.EndTime);

            bool checkResult = false;

            bool test2 = (checkTimeInput.CheckTime(hometownInput.StartTime));

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
                SettingsManager settingmanager = new SettingsManager();

                settingmanager.HometownLocation = hometownInput.SearchLocation;
                settingmanager.HometownSartTime = hometownInput.StartTime;
                settingmanager.WorkplaceEndTimer = hometownInput.EndTime;

                settingmanager.WorkplaceLocation = workplaceInput.SearchLocation;
                settingmanager.WorkplaceSartTime = workplaceInput.StartTime;
                settingmanager.WorkplaceEndTimer = workplaceInput.EndTime;




            }



        }
    }
}
