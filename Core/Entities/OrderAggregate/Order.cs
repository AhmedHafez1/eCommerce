using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities.OrderAggregate
{
    public class Order : BaseEntity
    {
        public string BuyerEmail { get; set; } = null!;
        public IEnumerable<OrderItem> OrderItems { get; set; } = [];
        public Address ShipToAddress { get; set; } = null!;
        public DeliveryMethod DeliveryMethod { get; set; } = null!;
        public OrderStatus Status { get; set; } = OrderStatus.Pending;
        public DateTime Date { get; set; } = DateTime.UtcNow;

        [Column(TypeName = "decimal(18,2)")]
        public decimal SubTotal { get; set; }

        public decimal GetTotal()
        {
            return SubTotal + DeliveryMethod.Price;
        }
    }

}