using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using sftest.Domain.Model;
using sftest.Infrastructure.Model;
using sftest.Infrastructure.Products;

namespace sftest.Infrastructure.OrderedProducts
{
    public class OrderedProductRepository : IOrderedProductRepository
    {
        private readonly IDbConnection _connection;
        private readonly IProductRepository _productRepository;

        public OrderedProductRepository(IDbConnection connection, IProductRepository productRepository)
        {
            _connection = connection;
            _productRepository = productRepository;
        }

        public async Task<List<OrderedProduct>> GetOrderedProductsByOrderId(Guid orderId)
        {
            const string sql = @"
                SELECT Id,OrderId, Unit, ProductId
                FROM sandfieldadmin.tb_order_product AS op
                WHERE op.OrderId = @OrderId;
            ";

            var orderedProducts = new List<OrderedProduct>();

            var orderedProductsDto = await _connection.QueryAsync<OrderedProductDto>(
                sql, new { OrderId = orderId });

            foreach (var orderedProductDto in orderedProductsDto)
            {
                var orderedProduct = new OrderedProduct()
                {
                    Id = orderedProductDto.Id,
                    OrderId = orderedProductDto.OrderId,
                    Unit = orderedProductDto.Unit
                };

                var product = await _productRepository.GetProductById(orderedProductDto.ProductId);

                orderedProduct.Product = product;

                orderedProducts.Add(orderedProduct);
            }

            return orderedProducts.ToList();
        }
    }
}