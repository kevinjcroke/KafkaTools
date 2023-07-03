using System;
using System.Collections.Generic;

namespace KafkaDummy.Schemas
{
    public sealed class FulfillmentStateSchema
    {
        public AddressSchema ShipTo { get; set; }
        public ContactSchema BillTo { get; set; }
        public string ShipFromId { get; set; }
        public FulfillmentOptionsSchema FulfillmentOptions { get; set; }
        public BrandSchema Branding { get; set; }
        public ReturnOptionsSchema ReturnOptions { get; set; }
        public OriginalOrderSourceSchema OriginalOrderSource { get; set; }
        public DateTime OrderDate { get; set; }
        public string ExternalFulfillmentId { get; set; }
        public string OrderNumber { get; set; }
        public string PartnerFulfillmentId { get; set; }
        public IEnumerable<FulfillmentLineItemSchema> Items { get; set; }
        //public IEnumerable<ShipmentSchema> Shipments { get; set; }
        public IEnumerable<DeliveryNotificationSchema> Deliveries { get; set; }
        public bool? HasCancellations { get; set; }
    }
}