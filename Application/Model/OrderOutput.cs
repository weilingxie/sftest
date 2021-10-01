using System;
using System.Collections.Generic;

namespace sftest.Application.Model
{
    public class OrderOutput
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public DateTime OrderDate { get; set; }
        public string ReferenceNumber { get; set; }
        public List<OrderedProductOutput> OrderedProducts { get; set; }
    }
}