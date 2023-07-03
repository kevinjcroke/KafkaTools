namespace KafkaDummy.Schemas
{
    public sealed class AddressSchema
    {
        public string Name { get; set; }
        public string Company { get; set; }
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string Line3 { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string State { get; set; }
        public string CountryCode { get; set; }
        public bool IsResidential { get; set; }
    }
}