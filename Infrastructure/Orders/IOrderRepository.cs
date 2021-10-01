using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using sftest.Domain.Model;

namespace sftest.Infrastructure.Orders
{
    public interface IOrderRepository
    {
        public Task<List<Order>> GetOrdersByCustomerId(Guid customerId);

        public Task<Order> GetOrderById(Guid orderId);
    }
}