using Confluent.Kafka;
using KafkaDummy.Schemas;
using System;

namespace KafkaDummy
{
    internal partial class Program
    {
        private static string BootstrapServers = "localhost:9092";
        private static string SchemaRegistryUrl = "http://localhost:8081";
        static void Main(string[] args)
        {
            using (var producer = new FulfillmentEventSchemaBuilder(new AvroSchemaRegistryClient(SchemaRegistryUrl), new KafkaProducerConfig(BootstrapServers))
                .Build())
            {
                var fillEvent = new FulfillmentEventSchema
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

                try
                {
                    producer.Produce("local-fulfillment-service-change-event-v0.1", new Message<Null, FulfillmentEventSchema> { Value = fillEvent });
                }
                catch (ProduceException<Null, FulfillmentEventSchema> e)
                {
                    Console.WriteLine($"Delivery failed: {e.Error.Reason}");
                }
            }
        }
    }
}
