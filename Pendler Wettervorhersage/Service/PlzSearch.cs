using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.Configuration.Attributes;
using System.Globalization;
using System.IO;

namespace Pendler_Wettervorhersage
{
    internal class PlzSearch
    {
        public List<PlzCsv> SearchPlz(int plz)
        {
            System.Diagnostics.Debug.WriteLine("test");
            using (var reader = new StreamReader("Resourcen/plz_geo.csv"))
            using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.GetCultureInfo("de-DE"))
            {
                Delimiter = ";",
                HasHeaderRecord = false
            }))
            {
                var records = csv.GetRecords<PlzCsv>().ToList();
                System.Diagnostics.Debug.WriteLine($"records {records}");
                var result = from record in records
                             where record.Plz == plz
                             select record;
                System.Diagnostics.Debug.WriteLine($"result: {result}");
                return result.ToList();
            }
        }
    }

    internal class PlzCsv
    {
        [Index(0)]
        public int Plz { get; set; }
        [Index(1)]
        public string Latidude { get; set; } = string.Empty;
        [Index(2)]
        public string Longitude { get; set; } = string.Empty;
    }
}
