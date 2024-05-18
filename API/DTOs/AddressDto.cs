namespace API.DTOs
{
    public class AddressDto
    {
        public int Id { get; set; }
        public string Building { get; set; } = null!;
        public string Street { get; set; } = null!;
        public string City { get; set; } = null!;
        public string? PostalCode { get; set; }
        public string? Country { get; set; }
    }
}
