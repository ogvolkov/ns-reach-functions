
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.WindowsAzure.Storage;
using NsReach.Functions.Data;
using NsReach.Functions.Models;

namespace NsReach.Functions
{
    public static class Stations
    {
        [FunctionName("Stations")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get")]HttpRequest req,
            ILogger log,
            ExecutionContext context
        )
        {
            log.LogInformation("Stations request");

            var stationsRepository = new StationsRepository(new CloudTableClientFactory());

            var stations = await stationsRepository.GetAllStations();

            var result = stations.Select(it => new StationModel(it.RowKey, it.Name, it.Latitude, it.Longitude));

            return new OkObjectResult(result);
        }
    }
}
