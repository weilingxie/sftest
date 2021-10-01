using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using sftest.Domain.Model;
using sftest.Infrastructure.Orders;

namespace sftest.Application.Orders.Query
{
    public class GetOrdersByCustomerIdQueryHandler : IRequestHandler<GetOrdersByCustomerIdQuery, List<Order>>
    {
        private readonly IOrderRepository _orderRepository;


        public GetOrdersByCustomerIdQueryHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<List<Order>> Handle(GetOrdersByCustomerIdQuery request,
            CancellationToken cancellationToken)
        {
            var orders = await _orderRepository.GetOrdersByCustomerId(request.CustomerId);

            return orders;
        }
    }
}