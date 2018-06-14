// Default URL for triggering event grid function in the local environment.
// http://localhost:7071/runtime/webhooks/EventGridExtensionConfig?functionName={functionname}

using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Azure.EventGrid.Models;
using Microsoft.Azure.WebJobs.Extensions.EventGrid;
using Phantom.Models;

namespace PhantomFuncApp
{
    public static class ContainerAFunc
    {
        [FunctionName("ContainerAFunc")]
        public static async Task Run([EventGridTrigger]EventGridEvent eventGridEvent, TraceWriter log)
        {
            log.Info("ContainerAFunc triggered");
            log.Info(eventGridEvent.Data.ToString());

            // Send event to custom topic
            var fileInfo = new CustomFileInfo
            {
                Filename = eventGridEvent.Subject,
                Available = true,
                Description = "This is from containera",
                OriginalData = eventGridEvent.Data
            };

            await Utils.SendEvent(fileInfo, "Phantom.NewFile.FileTypeA", "subjecta");
        }
    }
}
