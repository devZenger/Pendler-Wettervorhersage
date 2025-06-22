using System.IO;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace Pendler_Wettervorhersage.Service
{
    internal static class SettingsService
    {
        private static readonly string ConfigPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "settings.xml");

        private static AppSettings? _settings;

        public static AppSettings Current
        {
            get
            {
                if (_settings == null)
                    Load();
                if (_settings != null)
                    return _settings;
                else
                    throw new InvalidOperationException("Einstellungen nicht geladen");
            }
        }

        public static void Load()
        {
            if (!File.Exists(ConfigPath))
            {
                _settings = new AppSettings();
                Save();
            }
            {
                var serializer = new XmlSerializer(typeof(AppSettings));
                using var reader = new StreamReader(ConfigPath);
                
                var deserialzed = serializer.Deserialize(reader);
                if (deserialzed is AppSettings loadedSettings)
                {
                    _settings = loadedSettings;
                }
                else
                {
                    throw new InvalidDataException("Fehler beim Laden der Einstellungen");
                }
            }
        }

        public static void Save()
        {
            var serializer = new XmlSerializer(typeof(AppSettings));
            using var writer = new StreamWriter(ConfigPath);
            serializer.Serialize(writer, _settings);
        }
    }
}