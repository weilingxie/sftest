using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using sftest.Domain.Model;

namespace sftest.Infrastructure.Products
{
    public interface IProductRepository
    {
        public Task<Product> GetProductById(Guid productId);
    }
}