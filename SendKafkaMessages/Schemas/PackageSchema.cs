using System.Collections.Generic;

namespace KafkaDummy.Schemas
{
    public sealed class PackageSchema
    {
        public string TrackingNumber { get; set; }
        public IEnumerable<PackageItemSchema> Items { get; set; }
    }
}