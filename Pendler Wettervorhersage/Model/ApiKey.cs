namespace Pendler_Wettervorhersage
{
    internal class ApiKey : NotifyPropertyChangedBase
    {
        private string _storedApiKey = "ApiKey eingeben";
        public string StoredApiKey
        {
            get => _storedApiKey;
            set
            {
                if (_storedApiKey != value)
                {
                    _storedApiKey = value;
                    OnPropertyChanged();
                }
            }
        }
    }
}
