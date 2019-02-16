using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Net.Http;
using WooliesX.Exercises.Models;

namespace WooliesX.Exercises
{
    public static class TrolleyTotalFx
    {

        [FunctionName("trolleyTotal")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = null)] HttpRequest req,
            ILogger log,
            ExecutionContext executionContext)
        {            
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            Trolley trolley = JsonConvert.DeserializeObject<Trolley>(requestBody);           
            var calculator = new TrolleyTotalCalculator();
            var gTotal = calculator.Calculate(trolley);
            return new OkObjectResult(gTotal);
        }
    }
}
