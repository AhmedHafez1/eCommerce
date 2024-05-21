using Core.Entities.OrderAggregate;
using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class OrderService : IOrderService
    {
        public Task<Order> CreateOrderAsync(string buyerEmail, string basketId, int deliveryMethod, Address address)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<DeliveryMethod>> GetDeliveryMethodsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Order> GetOrderAsync(int orderId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Order>> GetOrdersAsync(string buyerEmail)
        {
            throw new NotImplementedException();
        }
    }
}
