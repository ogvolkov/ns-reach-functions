using Microsoft.WindowsAzure.Storage.Table;

namespace NsReach.Functions.Data.Entities
{
    public class StationEntity: TableEntity
    {
        public string Name { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }
    }
}
