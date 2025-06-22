namespace Pendler_Wettervorhersage
{
    public class AppSettings
    {
        public string ApiKey { get; set; } = "Bitte API-Key eingeben";
        public bool FirstStart { get; set; } = false;

        public string HometownLocation { get; set; } = "Pfaffenhofen";
        public string HometownStartTime { get; set; } = "7:00";
        public string HometownEndTime { get; set; } = "17:30";

        public string WorkplaceLocation { get; set; } = "München";
        public string WorkplaceStartTime { get; set; } = "8:00";
        public string WorkplaceEndTime { get; set; } = "16:30";
    }
}
