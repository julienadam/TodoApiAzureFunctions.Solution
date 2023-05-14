using System;
using System.Linq;
using System.Threading.Tasks;
using Azure.Data.Tables;
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
            [Table("Todos")] TableClient client,
            ILogger log)
        {
            log.LogInformation("Get on main page");

            var pages = client.Query<Todo>();
            return new OkObjectResult(pages.ToList());
        }
    }
}
