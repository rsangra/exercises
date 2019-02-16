using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using WooliesX.Exercises.Models;

namespace WooliesX.Exercises
{
    public static class UserFx
    {
        [FunctionName("user")]
        public static Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequest req,
            ILogger log,
            ExecutionContext executionContext)
        {
            var config = new ConfigurationFactory().Create(executionContext.FunctionAppDirectory);           
            return Task.FromResult<IActionResult>(
                new OkObjectResult(new TokenResponse(){ Name = config["user"], Token = config["apiKey"]}));
        }
    }
}
