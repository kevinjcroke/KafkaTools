using System;
using System.Collections.Generic;

namespace SendKafkaMessage.Schemas
{
    public sealed class ShipmentSchema
    {
        public string PartnerShipmentId { get; set; }
        public string TrackingNumber { get; set; }

        public string ShipmentNumber { get; set; }
        public string CarrierApiCode { get; set; }
        public string Carrier { get; set; }
        public string ShippingMethod { get; set; }
        public DateTime? ShipDate { get; set; }
        public IEnumerable<PackageSchema> Packages { get; set; }
        public AddressSchema ShipFrom { get; set; }
    }
}