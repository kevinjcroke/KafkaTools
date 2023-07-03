using System;

namespace KafkaDummy.Schemas
{
    public class DeliveryNotificationSchema
    {
        public string NotificationId { get; set; }
        public string OrderId { get; set; }
        public string ShipmentNumber { get; set; }
        public DateTime? DeliveredDate { get; set; }
        public string StandardizedStatusCode { get; set; }
    }
}
