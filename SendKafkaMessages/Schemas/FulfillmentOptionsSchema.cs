namespace KafkaDummy.Schemas
{
    public sealed class FulfillmentOptionsSchema
    {
        public string FulfillmentPolicy { get; set; }
        public string ShippingMethod { get; set; }
        public string RequestedShippingMethod { get; set; }
    }
}