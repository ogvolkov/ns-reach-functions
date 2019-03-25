using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage.Table;
using NsReach.Functions.Data.Entities;

namespace NsReach.Functions.Data
{
    public class StationsRepository
    {
        private const string _stationsTableName = "stations";

        private readonly CloudTableClientFactory _cloudTableClientFactory;

        public StationsRepository(CloudTableClientFactory cloudTableClientFactory)
        {
            _cloudTableClientFactory = cloudTableClientFactory ?? throw new ArgumentNullException(nameof(cloudTableClientFactory));
        }

        public async Task<IEnumerable<StationEntity>> GetAllStations()
        {
            var tableClient = _cloudTableClientFactory.Create();
            var stationsTable = tableClient.GetTableReference(_stationsTableName);

            var query = new TableQuery<StationEntity>();
            var stations = await stationsTable.ExecuteQuerySegmentedAsync(query, null);

            return stations.Results;
        }
    }
}
