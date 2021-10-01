using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using sftest.Application.Orders.Query;

namespace sftest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly ILogger<OrderController> _logger;
        private readonly IMediator _mediator;

        public OrderController(ILogger<OrderController> logger ,IMediator mediator)
        {
            _logger = logger;
            this._mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetOrdersByCustomerId(Guid customerId, CancellationToken cancellationToken)
        {
            _logger.LogTrace("Start GetOrdersByCustomerId");
            
            if (Guid.Empty == customerId) return BadRequest();

            var command = new GetOrdersByCustomerIdQuery(customerId);

            var result = await _mediator.Send(command, cancellationToken);

            return Ok(result);
        }
    }
}