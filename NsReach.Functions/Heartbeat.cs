
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace NsReach.Functions
{
    public static class Heartbeat
    {
        [FunctionName("Heartbeat")]
        public static IActionResult Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get")]HttpRequest req,
            ILogger log,
            ExecutionContext context
        )
        {
            return new OkObjectResult(null);
        }
    }
}
