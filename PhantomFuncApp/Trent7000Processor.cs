// Default URL for triggering event grid function in the local environment.
// http://localhost:7071/runtime/webhooks/EventGridExtensionConfig?functionName={functionname}

using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Azure.EventGrid.Models;
using Microsoft.Azure.WebJobs.Extensions.EventGrid;
using Phantom.Models;

namespace PhantomFuncApp
{
    public static class Trent7000Processor
    {
        [FunctionName("Trent7000Processor")]
        public static async Task Run([EventGridTrigger]EventGridEvent eventGridEvent, TraceWriter log)
        {
            log.Info("Trent7000Processor triggered");

            // Create a new event for this engine type.
            // Set the properties to reflect some information
            // about the engine as well as other related
            // details.
            var engineEvent = new EngineEvent
            {
                EngineType = Constants.EngineTypes.Trent7000,       // The engine type
                StorageEventData = eventGridEvent.Data,             // Data from the storage event
                Tags = new List<string>                             // Related metadata about the engine
                {
                    Constants.Tags.DeltaRefresh,
                    Constants.Tags.ExportControlled
                }
            };

            // Event Grid subscriptions can filter off of the Event Type and Subject fields.
            // Set the Event Type to reflect a new file uploaded from the source. The
            // Subject will be the type of engine - both can be used as filters.
            var eventType = Constants.EventTypes.NewFile;
            var subject = Constants.EngineTypes.Trent7000;

            // Send the event to a custom topic.
            await Utils.SendEvent(
                engineEvent,        // event data
                eventType,          // event type
                subject);           // event subject
        }
    }
}
