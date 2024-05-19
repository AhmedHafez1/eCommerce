namespace Core.Entities.OrderAggregate
{
    public class ProductItemOrdered
    {
        public int ProductItemId { get; set; }
        public string ProductName { get; set; } = null!;
        public string? PictureUrl { get; set; }
    }
}
