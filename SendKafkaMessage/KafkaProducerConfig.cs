using Confluent.Kafka;
using System.Net;

namespace SendKafkaMessage
{
    internal partial class Program
    {
        public class KafkaProducerConfig : ProducerConfig
        {
            public KafkaProducerConfig(string schemaUrl)
            {
                BootstrapServers = schemaUrl;
                ClientId = Dns.GetHostName();
                LingerMs = 50;
                DeliveryReportFields = "none";
            }
        }
    }
}
