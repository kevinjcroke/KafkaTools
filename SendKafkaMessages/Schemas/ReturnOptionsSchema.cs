namespace KafkaDummy.Schemas
{
    public sealed class ReturnOptionsSchema
    {
        string WarehouseId { get; set; }
        AddressSchema Address { get; set; }
    }
}