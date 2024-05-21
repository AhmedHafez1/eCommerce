using Core.Entities.OrderAggregate;

namespace Core.Interfaces
{
    public interface IOrderService
    {
        Task<Order> CreateOrderAsync(string buyerEmail, string basketId, int deliveryMethod, Address address);

        Task<IEnumerable<Order>> GetOrdersAsync(string buyerEmail);

        Task<Order> GetOrderAsync(int orderId);

        Task<IEnumerable<DeliveryMethod>> GetDeliveryMethodsAsync();
    }
}
