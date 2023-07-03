using Confluent.SchemaRegistry;

namespace SendKafkaMessage
{
    internal partial class Program
    {
        public class AvroSchemaRegistryClient : CachedSchemaRegistryClient
        {
            public AvroSchemaRegistryClient(string schemaUrl) : base(
                new SchemaRegistryConfig { Url = schemaUrl })
            {
            }
        }
    }
}
