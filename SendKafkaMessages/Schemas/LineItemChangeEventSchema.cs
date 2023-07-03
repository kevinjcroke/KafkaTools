namespace KafkaDummy.Schemas
{
    public class LineItemChangeEventSchema
    {
        public FulfillmentStatus ChangeFulfillmentStatus { get; set; }
        public string LineItemExternalId { get; set; }
        public decimal? PreviousQuantity { get; set; }
        public decimal? Quantity { get; set; }
        public decimal TotalQuantity { get; set; }
    }
}