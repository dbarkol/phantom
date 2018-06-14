// Default URL for triggering event grid function in the local environment.
// http://localhost:7071/runtime/webhooks/EventGridExtensionConfig?functionName={functionname}

using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Azure.EventGrid.Models;
using Microsoft.Azure.WebJobs.Extensions.EventGrid;

namespace PhantomFuncApp
{
    public static class ContainerAFunc
    {
        [FunctionName("ContainerAFunc")]
        public static void Run([EventGridTrigger]EventGridEvent eventGridEvent, TraceWriter log)
        {
            log.Info("ContainerAFunc triggered");
            log.Info(eventGridEvent.Data.ToString());

            // Send event to custom topic
            // TODO: Implement
        }
    }
}
