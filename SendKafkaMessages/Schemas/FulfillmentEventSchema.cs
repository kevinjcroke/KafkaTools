using System.Collections.Generic;

namespace KafkaDummy.Schemas
{
    public class FulfillmentEventSchema
    {
        public string TenantId { get; set; }
        public string ExternalClientId { get; set; }
        public string ExternalFulfillmentId { get; set; } // external_id
        public FulfillmentStateSchema State { get; set; }
        //public IEnumerable<LineItemChangeEventSchema> LineItemChanges { get; set; }
        public string FulfillmentChange { get; set; }
    }
}