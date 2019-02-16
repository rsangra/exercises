using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Net.Http;
using WooliesX.Exercises.Extensions;
using WooliesX.Exercises.Enums;

namespace WooliesX.Exercises
{

    public static class SortFx
    {        
        private static WooliesXService wooliesService = new WooliesXService(new HttpClient());

        [FunctionName("sort")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
            ILogger log,
            ExecutionContext executionContext)
        {
            log.LogInformation("SortFx function run");
            // read config
            var config = new ConfigurationFactory().Create(executionContext.FunctionAppDirectory);
            // init woolies service
            wooliesService.Token = config["apiKey"];

            // read sort option
            string name = req.Query["sortOption"];

            SortBy sortBy;
            if (!Enum.TryParse<SortBy>(name, true, out sortBy))
            {
                return new BadRequestObjectResult("Please pass a sort option from range low, high, ascending, descending, recommended");
            }
            switch (sortBy)
            {
                case SortBy.Low:
                case SortBy.High:
                case SortBy.Ascending:
                case SortBy.Descending:
                    return new OkObjectResult((await wooliesService.GetProducts()).Sort(sortBy));
                case SortBy.Recommended:
                    return new OkObjectResult( (await wooliesService.GetShopperHistory()).SortRecommended());
            }

            return new BadRequestObjectResult("No valid option used");
        }
    }
}
