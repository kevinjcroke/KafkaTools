using Chr.Avro.Confluent;
using Confluent.Kafka;
using Confluent.Kafka.SyncOverAsync;
using SendKafkaMessage.Schemas;
using System;

namespace SendKafkaMessage
{
    internal partial class Program
    {
        private const string Topic = "local-fulfillment-service-change-event-v0.1";
        private static string BootstrapServers = "localhost:9092";
        private static string SchemaRegistryUrl = "http://localhost:8081";

        private static FulfillmentEventSchema message = new FulfillmentEventSchema
        {
            TenantId = "200002",
            ExternalFulfillmentId = "ext",
            ExternalClientId = "123456",
            State = new FulfillmentStateSchema
            {
                HasCancellations = false,
                Items = new FulfillmentLineItemSchema[]
                {
                    new FulfillmentLineItemSchema
                    {
                        Quantity = new FulfillmentQuantitySchema
                        {
                            Total=1,
                            Shipped=1
                        },

                    }
                }
            }
        };

        static void Main(string[] args)
        {
            var schemaBuilder = new ProducerBuilder<Null, FulfillmentEventSchema>(new KafkaProducerConfig(BootstrapServers));
            var serializer = new AsyncSchemaRegistrySerializer<FulfillmentEventSchema>(new AvroSchemaRegistryClient(SchemaRegistryUrl))
                    .AsSyncOverAsync();
            schemaBuilder.SetValueSerializer(serializer);

            using (var producer = schemaBuilder.Build())
            {
                try
                {
                    producer.Produce(Topic, new Message<Null, FulfillmentEventSchema> { Value = message });
                    Console.WriteLine($"Delivered '{message}' to '{producer.Name}'");
                }
                catch (ProduceException<Null, FulfillmentEventSchema> e)
                {
                    Console.WriteLine($"Delivery failed: {e.Error.Reason}");
                }
                Console.WriteLine("Press any key to exit");
                Console.ReadKey();
            }
        }
    }
}
