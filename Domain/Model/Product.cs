using System;

namespace sftest.Domain.Model
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string ProductType { get; set; }
        public decimal Price { get; set; }
    }
}