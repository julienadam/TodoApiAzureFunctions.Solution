using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;

namespace TodoApiAzureFunctions;

public static class DeleteTodo
{
    [FunctionName("DeleteTodo")]
    public static async Task<IActionResult> Run(
        [HttpTrigger(AuthorizationLevel.Anonymous, "delete", Route = "todos")] HttpRequest req,
        ILogger log)
    {
        log.LogInformation("Deleting all todos");

        // Enrich object with Id and save
        return new OkObjectResult(new Todo[] {});
    }
}