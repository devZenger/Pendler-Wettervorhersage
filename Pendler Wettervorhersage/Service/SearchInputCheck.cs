namespace Pendler_Wettervorhersage
{
    internal class SearchInputCheck
    {
        public bool CheckInput(SearchParameter input)
        {
            bool testLocation = LocationCheck(input.SearchLocation);

            bool testStartTime = CheckTime(input.StartTime);

            bool testEndTime = CheckTime(input.EndTime);

            if (testLocation || testStartTime || testEndTime)
                return false;
            else
                return true;
        }
        private bool LocationCheck(string input)
        {
            bool test = String.IsNullOrEmpty(input);
            if (input == "Ort eingeben")
                test = true;
            return test;
        }
        private bool CheckTime(string timeInput)
        {
            int[] timeResult = new int[2];
            bool timeTest = true;
            string[] timeSplit = timeInput.Split(':');

            if (timeSplit.Length != 2)
            {
                return timeTest;
            }
            else if (timeSplit[1].Length != 2)
            {
                return timeTest;
            }
            else
            {
                bool[] test = new bool[2];
                for (int j = 0; j < 2; j++)
                {
                    test[j] = int.TryParse(timeSplit[j], out timeResult[j]);

                    if (test[j] == false)
                    {
                        break;
                    }

                    if (timeResult[0] <= 24 && timeResult[0] >= 0 && test[0] == true)
                    {

                        if (timeResult[1] <= 60 && timeResult[1] >= 0 && test[1] == true)
                        { timeTest = false; }
                    }
                }
            }
            return timeTest;
        }
    }
}
