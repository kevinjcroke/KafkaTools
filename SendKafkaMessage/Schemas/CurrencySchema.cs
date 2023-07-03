using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace SendKafkaMessage.Schemas
{
    public sealed class CurrencySchema
    {
        public decimal? Value { get; set; }

        public string Code { get; set; }
    }
}