using Chr.Avro.Confluent;
using Confluent.Kafka;
using Confluent.Kafka.SyncOverAsync;
using KafkaDummy.Schemas;

namespace KafkaDummy
{
    internal partial class Program
    {
        public class FulfillmentEventSchemaBuilder : ProducerBuilder<Null, FulfillmentEventSchema>
        {
            public FulfillmentEventSchemaBuilder(AvroSchemaRegistryClient schemaRegistryClient, KafkaProducerConfig config)
                : base(config)
            {
                var serializer = new AsyncSchemaRegistrySerializer<FulfillmentEventSchema>(schemaRegistryClient)
                    .AsSyncOverAsync();
                SetValueSerializer(serializer);
            }
        }
    }
}
