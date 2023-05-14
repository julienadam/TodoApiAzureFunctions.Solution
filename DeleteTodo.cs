using System;
using System.Threading.Tasks;
using Azure.Data.Tables;
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
        [Table("Todos")] TableClient client,
        ILogger log)
    {
        log.LogInformation("Deleting all todos");

        await client.DeleteAsync();

        return new OkObjectResult(Array.Empty<Todo>());
    }
}