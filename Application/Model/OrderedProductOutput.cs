using System;

namespace sftest.Application.Model
{
    public class OrderedProductOutput
    {
        public int Id { get; set; }
        public Guid OrderId { get; set; }
        public int Unit { get; set; }
        public decimal Price { get; set; }
        public string Name { get; set; }
        public string ProductType { get; set; }
    }
}