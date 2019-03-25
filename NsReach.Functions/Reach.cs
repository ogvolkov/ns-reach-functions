
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using NsReach.Functions.Data;
using NsReach.Functions.Models;

namespace NsReach.Functions
{
    public static class Reach
    {
        [FunctionName("Reach")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get")]HttpRequest req,
            ILogger log,
            ExecutionContext context
        )
        {
            log.LogInformation("Reach request");

            string from = req.Query["from"];

            if (string.IsNullOrEmpty(from))
            {
                return new BadRequestErrorMessageResult("from is missing");
            }

            var repository = new TripTimesRepository(new CloudTableClientFactory());

            var tripTimes = await repository.GetTripTimes(from);

            var results = tripTimes.Select(it => new ReachableStationModel(it.RowKey, it.Time));

            return new OkObjectResult(results);
        }
    }
}
