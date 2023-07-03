using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace KafkaDummy.Schemas
{
    public sealed class CurrencySchema
    {
        public decimal? Value { get; set; }

        public string Code { get; set; }
    }
}