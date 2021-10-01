using System;

namespace sftest.Infrastructure.Model
{
    public class OrderedProductDto
    {
        public int Id { get; set; }
        public Guid OrderId { get; set; }
        public int Unit { get; set; }
        public Guid ProductId { get; set; }
    }
}