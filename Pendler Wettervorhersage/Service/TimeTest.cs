namespace Pendler_Wettervorhersage
{
    internal class TimeTest
    {


        public bool CheckTime(string timeInput)
        {
            int[] timeResult = new int[2];
            bool timeTest = false;

            
            
                string[] timeSplit = timeInput.Split(':');
                if (timeSplit.Length != 2)
                {
                    Console.WriteLine("falsche eingabe");
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
                            { timeTest = true; }
                        }
                    }
                }

            return timeTest;
        }
    }
}