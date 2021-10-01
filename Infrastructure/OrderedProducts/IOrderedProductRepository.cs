using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using sftest.Domain.Model;

namespace sftest.Infrastructure.OrderedProducts
{
    public interface IOrderedProductRepository
    {
        public Task<List<OrderedProduct>> GetOrderedProductsByOrderId(Guid orderId);
    }
}