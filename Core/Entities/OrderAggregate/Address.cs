namespace Core.Entities.OrderAggregate
{
    public class Address
    {
        public string Building { get; set; } = null!;
        public string Street { get; set; } = null!;
        public string City { get; set; } = null!;
        public string? PostalCode { get; set; }
        public string Country { get; set; } = null!;
    }
}
