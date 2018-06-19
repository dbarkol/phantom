using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Azure.EventGrid;
using Microsoft.Azure.EventGrid.Models;
using Microsoft.Rest;
using Phantom.Models;

namespace PhantomFuncApp
{
    internal static class Utils
    {
        internal static async Task SendEvent(object eventData, string eventType, string subject)
        {
            var topicHostName = Environment.GetEnvironmentVariable("TopicHostName");
            var topicKey = Environment.GetEnvironmentVariable("TopicKey");

            ServiceClientCredentials credentials = new TopicCredentials(topicKey);
            var client = new EventGridClient(credentials);

            var events = new List<EventGridEvent>
            {
                new EventGridEvent()
                {
                    Id = Guid.NewGuid().ToString(),
                    Data = eventData,
                    EventTime = DateTime.UtcNow,
                    EventType = eventType,
                    Subject = subject,
                    DataVersion = "1.0"
                }
            };

            await client.PublishEventsAsync(
                topicHostName,
                events);
        }

    }
}
