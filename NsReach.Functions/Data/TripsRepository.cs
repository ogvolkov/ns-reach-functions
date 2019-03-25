using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage.Table;
using NsReach.Functions.Data.Entities;

namespace NsReach.Functions.Data
{
    public class TripTimesRepository
    {
        private const string _tripTimesTableName = "tripTimes";

        private readonly CloudTableClientFactory _cloudTableClientFactory;

        public TripTimesRepository(CloudTableClientFactory cloudTableClientFactory)
        {
            _cloudTableClientFactory = cloudTableClientFactory ?? throw new ArgumentNullException(nameof(cloudTableClientFactory));
        }

        public async Task<IEnumerable<TripTimeEntity>> GetTripTimes(string from)
        {
            var tableClient = _cloudTableClientFactory.Create();
            var tripTimesTable = tableClient.GetTableReference(_tripTimesTableName);

            var query = new TableQuery<TripTimeEntity>()
                .Where(TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, from));

            var tripTimes = await tripTimesTable.ExecuteQuerySegmentedAsync(query, null);

            return tripTimes.Results;
        }
    }
}
