namespace SendKafkaMessage.Schemas
{
    public sealed class OriginalOrderSourceSchema
    {
        public string OriginalMarketplaceCode { get; set; }
        public string OriginalFulfillmentPolicy { get; set; }
    }
}