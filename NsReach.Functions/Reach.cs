
using System.IO;
using System.Linq;
using System.Web.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs.Host;
using Newtonsoft.Json;
using NsReach.Functions.Dto;
using NsReach.Functions.Models;

namespace NsReach.Functions
{
    public static class Reach
    {
        [FunctionName("Reach")]
        public static IActionResult Run([HttpTrigger(AuthorizationLevel.Anonymous, "get")]HttpRequest req, TraceWriter log)
        {
            log.Info("Reach");

            string from = req.Query["from"];

            if (string.IsNullOrEmpty(from))
            {
                return new BadRequestErrorMessageResult("from is missing");
            }

            RouteDto[] routeDtos;

            var serializer = new JsonSerializer();

            using (var streamReader = File.OpenText(@"Data\times.json"))
            using (var jsonReader = new JsonTextReader(streamReader))
            {
                routeDtos = serializer.Deserialize<RouteDto[]>(jsonReader);
            }

            var reachableStations = routeDtos
                .Where(route => route.From == from)
                .Select(route => new ReachableStationModel(route.To, ParseTime(route.Time)));

            return new OkObjectResult(reachableStations);
        }

        private static int ParseTime(string timeString)
        {
            var parts = timeString.Split(':');

            int hours = int.Parse(parts[0]);
            int minutes = int.Parse(parts[1]);

            return hours * 60 + minutes;
        }
    }
}
