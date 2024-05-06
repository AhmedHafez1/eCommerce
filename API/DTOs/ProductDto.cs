namespace Core.DTOs
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public string? PictureUrl { get; set; }
        public string ProductType { get; set; } = null!;
        public string ProductBrand { get; set; } = null!;
    }
}
