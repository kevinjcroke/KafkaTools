namespace KafkaDummy.Schemas
{
    public sealed class FulfillmentQuantitySchema
    {
        public decimal Total { get; set; }
        public decimal Shipped { get; set; }
        public FulfillmentCancelledQuantityValueSchema Cancelled { get; set; }
        public FulfillmentRejectedQuantityValueSchema Rejected { get; set; }
        public FulfillmentRejectedQuantityValueSchema Unknown { get; set; }
    }
}