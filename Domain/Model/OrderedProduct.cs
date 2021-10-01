using System;

namespace sftest.Domain.Model
{
    public class OrderedProduct
    {
        public int Id { get; set; }
        public Guid OrderId { get; set; }
        public int Unit { get; set; }
        public Product Product { get; set; }
    }
}