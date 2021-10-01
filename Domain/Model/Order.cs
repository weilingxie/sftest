using System;
using System.Collections.Generic;

namespace sftest.Domain.Model
{
    public class Order
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public DateTime OrderDate { get; set; }
        public string ReferenceNumber { get; set; }
        public List<OrderedProduct> OrderedProducts { get; set; }
    }
}