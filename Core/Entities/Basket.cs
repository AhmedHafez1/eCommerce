namespace Core.Entities
{
    public class Basket
    {
        public string? Id { get; set; }
        public List<BasketItem> BasketItems { get; set; } = [];
    }
}
