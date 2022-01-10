using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Xenhey.BPM.Core.Implementation;
using Xenhey.BPM.Core;
using System.Linq;
using System.Collections.Specialized;
using System.Collections.Generic;

namespace ETLWithAzure
{
        public class Upload
        {
            private HttpRequest _req;
            private NameValueCollection nvc = new NameValueCollection();
            [FunctionName("Upload")]
            public async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = null)]
            HttpRequest req, ILogger log)
            {
                _req = req;
                string ApiKeyName = "x-api-key";
                log.LogInformation("C# HTTP trigger function processed a request.");
                var batchFileResults = orchrestatorService.Run(_req.Body);
                var listBatchFiles = JsonConvert.DeserializeObject<List<dynamic>>(batchFileResults);
                var ProcesssedFolderName = listBatchFiles[0]["PartitionKey"].ToString();
                nvc.Remove(ApiKeyName);
                nvc.Add(ApiKeyName, "B6B6768321C749B5B52380A16DC120AH");
                var results = orchrestatorService.Run(ProcesssedFolderName);
                return resultSet(results);




                return resultSet(results);

            }

            private ActionResult resultSet(string reponsePayload)
            {
                var returnContent = new ContentResult();
                var mediaSelectedtype = _req.Headers.Where(x => x.Key.Equals("Content-Type")).FirstOrDefault();
                returnContent.Content = reponsePayload;
                returnContent.ContentType = mediaSelectedtype.Value;
                return returnContent;
            }
            private IOrchrestatorService orchrestatorService
            {
                get
                {

                    _req.Headers.ToList().ForEach(item =>
                    {
                        nvc.Add(item.Key, item.Value.FirstOrDefault());
                    });
                    return new ManagedOrchestratorService(nvc);
                }
            }

    }
}