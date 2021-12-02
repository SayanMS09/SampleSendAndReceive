using System;
using System.Text;
using System.Threading.Tasks;
using Azure.Storage.Blobs;
using Azure.Messaging.EventHubs;
using Azure.Messaging.EventHubs.Consumer;
using Azure.Messaging.EventHubs.Processor;

namespace ReceiveTest
{
    class Receiver
    {
        private const string ehubNamespaceConnectionString = "Endpoint=sb://hmlam-sn1-501-001.servicebus.windows-int.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=D2bJ7Hh8G2hFhWO1WrdSNKecTF7yBn8n9QxCktQ+13c=";
        private const string eventHubName = "sayan-eh-9";

        static async Task Main()
        {
            // Read from the default consumer group: $Default
            string consumerGroup = EventHubConsumerClient.DefaultConsumerGroupName;

            // Create an event processor client to process events in the event hub
            EventHubConsumerClient eventConsumer = new EventHubConsumerClient(consumerGroup, ehubNamespaceConnectionString, eventHubName);

            // Start the processing
            await foreach (PartitionEvent partitionEvent in eventConsumer.ReadEventsAsync())
            {
                Console.WriteLine("---Execution from ConsumerReadEvent method---");
                Console.WriteLine("------");
                Console.WriteLine("Event Data recieved {0} ", Encoding.UTF8.GetString(partitionEvent.Data.Body.ToArray()));
                if (partitionEvent.Data != null)
                {
                    Console.WriteLine("Event Data {0} ", Encoding.UTF8.GetString(partitionEvent.Data.Body.ToArray()));
                }
            }
        }
    }
}
