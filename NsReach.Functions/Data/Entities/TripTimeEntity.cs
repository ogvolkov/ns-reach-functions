using Microsoft.WindowsAzure.Storage.Table;

namespace NsReach.Functions.Data.Entities
{
    public class TripTimeEntity: TableEntity
    {
        /// <summary>
        /// Time in minutes
        /// </summary>
        public int Time { get; set; }
    }
}
