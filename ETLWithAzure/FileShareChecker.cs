using System;
using System.Collections.Specialized;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using Xenhey.BPM.Core;
using Xenhey.BPM.Core.Implementation;

namespace ETLWithAzure
{
    public  class FileShareChecker
    {
        private NameValueCollection nvc = new NameValueCollection();

        [FunctionName("FileShareChecker")]
        public void Run([TimerTrigger("%TimerInterval%")] TimerInfo myTimer, ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");
            string ApiKeyName = "x-api-key";
            //Ge file and update database information.
            nvc.Add(ApiKeyName, "43EFE991E8614CFB9EDECF1B0FDED37B");
            string requestBody = "{\"ProcessStarted\" : \"Yes\" }";
            var uploadFile = orchrestatorService.Run(requestBody);
            log.LogInformation(uploadFile);
        }

        private IOrchrestatorService orchrestatorService
        {
            get
            {
                return new LocalOrchestratorService(nvc);
            }
        }
    }
}
