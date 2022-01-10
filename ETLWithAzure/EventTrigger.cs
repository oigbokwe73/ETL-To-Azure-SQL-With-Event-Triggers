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
    public static class EventTrigger
    {
        [FunctionName("EventTrigger")]
        public static void Run([BlobTrigger("samples-workitems/{name}", Connection = "")]Stream myBlob, string name, ILogger log)
        {
            string ApiKeyName = "x-api-key";
            log.LogInformation("C# blob trigger function processed a request.");
            NameValueCollection nvc = new NameValueCollection();
            nvc.Add(ApiKeyName, "B6B6768321C749B5B52380A16DC120AH");
            IOrchrestatorService orchrestatorService = new ManagedOrchestratorService(nvc);
            var processFiles = orchrestatorService.Run(myBlob);
        }
    }
}
