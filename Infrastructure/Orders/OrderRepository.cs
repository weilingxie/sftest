using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using sftest.Domain.Model;
using sftest.Infrastructure.OrderedProducts;

namespace sftest.Infrastructure.Orders
{
    public class OrderRepository : IOrderRepository
    {
        private readonly IDbConnection _connection;
        private readonly IOrderedProductRepository _orderedProductRepository;

        public OrderRepository(IDbConnection connection, IOrderedProductRepository orderedProductRepository)
        {
            _connection = connection;
            _orderedProductRepository = orderedProductRepository;
        }

        public async Task<List<Order>> GetOrdersByCustomerId(Guid customerId)
        {
            const string sql = @"
                SELECT Id
                FROM sandfieldadmin.tb_order AS o
                WHERE o.CustomerId = @CustomerId;
            ";

            var orderIds = await _connection.QueryAsync<Guid>(
                sql, new { CustomerId = customerId });

            var orders = new List<Order>();

            foreach (var orderId in orderIds)
            {
                var order = await GetOrderById(orderId);
                orders.Add(order);
            }

            return orders.ToList();
        }

        public async Task<Order> GetOrderById(Guid orderId)
        {
            const string sql = @"
                SELECT Id,CustomerId, OrderDate, ReferenceNumber
                FROM sandfieldadmin.tb_order AS o
                WHERE o.Id = @OrderId;
            ";

            var order = await _connection.QueryFirstAsync<Order>(
                sql, new { OrderId = orderId });

            var orderedProducts = await _orderedProductRepository.GetOrderedProductsByOrderId(order.Id);
            order.OrderedProducts = orderedProducts;

            return order;
        }
    }
}