using CsvHelper;
using System.Globalization;
using System.IO;

namespace Pendler_Wettervorhersage
{
    internal class PlzSearch
    {
        public List<PlzCsv> SearchPlz(int plz)
        {
            using (var reader = new StreamReader("PLZ.csv"))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var records = csv.GetRecords<PlzCsv>().ToList();

                var result = from record in records
                             where record.Plz == plz
                             select record;

                return result.ToList();
            }
        }
    }

    internal class PlzCsv
    {
        public int Plz { get; set; }
        public string City { get; set; } = string.Empty;
        public string Longitude { get; set; } = string.Empty;
        public string Latidude { get; set; } = string.Empty;
    }
}
