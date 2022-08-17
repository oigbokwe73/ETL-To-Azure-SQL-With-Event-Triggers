using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Xenhey.BPM.Core;
using Xenhey.BPM.Core.Implementation;

namespace ETLWithAzure
{
    public static class EventParser
    {
        [FunctionName("EventParser")]
        public static void Run([BlobTrigger("pickup/{name}", Connection = "AzureWebJobsStorage")] Stream myBlob, string name, ILogger log)
        {
            string ApiKeyName = "x-api-key";
            log.LogInformation("C# blob trigger function processed a request.");
            NameValueCollection nvc = new NameValueCollection();
            nvc.Add(ApiKeyName, "3FB620B0E0FD4E8F93C9E4D839D00E1C");
            IOrchrestatorService orchrestatorService = new LocalOrchestratorService(nvc);
            var processFiles = orchrestatorService.Run(myBlob);
        }
    }
}
