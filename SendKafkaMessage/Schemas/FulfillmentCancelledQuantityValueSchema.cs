namespace SendKafkaMessage.Schemas
{
    public sealed class FulfillmentCancelledQuantityValueSchema
    {
        public decimal Value { get; set; }
        public string Reason { get; set; }
    }
}