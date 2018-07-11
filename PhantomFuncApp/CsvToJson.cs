
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs.Host;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace PhantomFuncApp
{
    public static class CsvToJson
    {
        [FunctionName("CsvToJson")]
        public static IActionResult Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)]HttpRequest req, 
            TraceWriter log)
        {
            log.Info("CsvToJson triggered");

            var requestBody = new StreamReader(req.Body).ReadToEnd();
            var csvLines = requestBody.Split('\r');

            var items = new Dictionary<string, string>();
            foreach (var line in csvLines)
            {
                var lineAttr = line.Split(',');
                if (lineAttr.Length != 2) continue;
                items.Add(lineAttr[0].Replace("\n", ""), lineAttr[1]);
            }

            return new ContentResult { Content = JsonConvert.SerializeObject(items), ContentType = "application/json" };
        }
    }
}
