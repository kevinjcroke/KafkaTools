namespace KafkaDummy.Schemas
{
    public sealed class ContactSchema
    {
        public string Name { get; set; }
        public string Company { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public ContactAddressSchema Address { get; set; }
    }
}