namespace Core.Entities.Identity
{
    public class Address
    {
        public int Id { get; set; }
        public string Building { get; set; } = null!;
        public string Street { get; set; } = null!;
        public string City { get; set; } = null!;
        public string? PostalCode { get; set; }
        public string Country { get; set; } = null!;
        public AppUser AppUser { get; set; } = null!;
        public string AppUserId { get; set; } = null!;
    }
}