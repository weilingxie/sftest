using System;
using System.Data;
using System.Threading.Tasks;
using Dapper;
using sftest.Domain.Model;

namespace sftest.Infrastructure.Products
{
    public class ProductRepository : IProductRepository
    {
        private readonly IDbConnection _connection;

        public ProductRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public async Task<Product> GetProductById(Guid productId)
        {
            const string sql = @"
                SELECT Id,Name, ProductType, Price
                FROM sandfieldadmin.tb_product AS p
                WHERE p.Id = @ProductId;
            ";

            var product = await _connection.QueryFirstAsync<Product>(
                sql, new { ProductId = productId });

            return product;
        }
    }
}