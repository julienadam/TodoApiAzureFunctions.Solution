using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace TodoApiAzureFunctions
{
    public static class GetHome
    {
        [FunctionName("GetHome")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "todos")] HttpRequest req, 
            ILogger log)
        {
            log.LogInformation("Get on main page");
            return new OkObjectResult(new Todo[] {});
        }
    }
}
