using System;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace TodoApiAzureFunctions
{
    public static class PostTodo
    {
        [FunctionName("PostTodo")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "todos")] HttpRequest req,
            [Table("Todos")] IAsyncCollector<Todo> toDoItems,
            ILogger log)
        {
            var requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            log.LogInformation("Posting todo.\n" + requestBody);
            var postedTodo = JsonConvert.DeserializeObject<Todo>(requestBody);
            postedTodo.Id = Guid.NewGuid().ToString();
            postedTodo.Url = req.GetEncodedUrl() + "/" + postedTodo.Id;

            // Enrich object with Id and save
            await toDoItems.AddAsync(postedTodo);
            return new JsonResult(postedTodo);
        }
    }
}
