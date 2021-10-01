using System;
using System.Collections.Generic;
using MediatR;
using sftest.Domain.Model;

namespace sftest.Application.Orders.Query
{
    public class GetOrdersByCustomerIdQuery : IRequest<List<Order>>
    {
        public readonly Guid CustomerId;

        public GetOrdersByCustomerIdQuery(Guid customerId)
        {
            CustomerId = customerId;
        }
    }
}