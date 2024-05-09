namespace Core.Classes
{
    public class ProductQueryParams
    {
        public string? Sort { get; set; }
        public int PageIndex { get; set; } = 1;
        public int PageSize { get; set; } = 6;
        public int? BrandId { get; set; }
        public int? TypeId { get; set; }
    }
}
