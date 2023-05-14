using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;

namespace TodoApiAzureFunctions;

public static class GetSpecific
{
    [FunctionName("GetSpecific")]
    public static async Task<IActionResult> Run(
        [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "todos/{id:guid}")] HttpRequest req,
        [Table("Todos", "Http", "{id}")] Todo poco,
        Guid id,
        ILogger log)
    {
        log.LogInformation("Get on specific id " + id);
            
        return new OkObjectResult(poco);
    }
}