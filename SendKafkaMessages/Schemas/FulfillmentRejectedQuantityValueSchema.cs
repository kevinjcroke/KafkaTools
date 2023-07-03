namespace KafkaDummy.Schemas
{
    public sealed class FulfillmentRejectedQuantityValueSchema
    {
        public decimal Value { get; set; }
        public string Reason { get; set; }
    }
}