namespace SendKafkaMessage.Schemas
{
    public sealed class FulfillmentLineItemSchema
    {
        public string ExternalLineItemId { get; set; }
        public string Sku { get; set; }
        public string Description { get; set; }
        public FulfillmentQuantitySchema Quantity { get; set; }
        public CurrencySchema UnitPrice { get; set; }
    }
}