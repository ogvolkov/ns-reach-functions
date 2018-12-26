
using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using NsReach.Functions.Dto;
using NsReach.Functions.Models;

namespace NsReach.Functions
{
    public static class Stations
    {
        [FunctionName("Stations")]
        public static IActionResult Run([HttpTrigger(AuthorizationLevel.Anonymous, "get")]HttpRequest req, ILogger log)
        {
            log.LogInformation("Stations request");

            StationDto[] stationDtos;

            var serializer = new JsonSerializer();

            using (var streamReader = File.OpenText(@"Data\stations.json"))
            using (var jsonReader = new JsonTextReader(streamReader))
            {
                stationDtos = serializer.Deserialize<StationDto[]>(jsonReader);
            }

            var stations = stationDtos.Select(it =>
                new StationModel(it.Code, it.Name, float.Parse(it.Lat), float.Parse(it.Lon))
            );

            return new OkObjectResult(stations);
        }
    }
}
