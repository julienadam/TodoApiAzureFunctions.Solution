using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;

namespace TodoApiAzureFunctions
{
    public static class PostTodo
    {
        [FunctionName("PostTodo")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "todos")] Todo postedTodo,
            ILogger log)
        {
            log.LogInformation("Posting todo");
            
            // Enrich object with Id and save
            var result = postedTodo with { Id = Guid.NewGuid().ToString() };
            return new OkObjectResult(result);
        }
    }
}
