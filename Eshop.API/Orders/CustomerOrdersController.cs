using Eshop.Application.Orders.CustomerOrder.Commands;
using Eshop.Application.Orders.CustomerOrder.Queries;
using Eshop.Application.Shared;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Eshop.API.Orders
{
    [Route("api/v1/customers")]
    [ApiController]
    public class CustomerOrdersController : Controller
    {
        private readonly IMediator _mediator;

        public CustomerOrdersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Retrieves customer orders.
        /// </summary>
        /// <param name="orderId">Order ID.</param>
        [Route("{customerId}/orders")]
        [HttpGet]
        [ProducesResponseType(typeof(OrderDto), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetCustomerOrderDetails([FromRoute] Guid customerId)
        {
            var orderDetails = await _mediator.Send(new GetOrderQuery(customerId));
            return Ok(orderDetails);
        }

        /// <summary>
        /// Adds a new order for a specified customer.
        /// </summary>
        /// <param name="customerId">Customer ID.</param>
        /// <param name="request">List of products.</param>
        [Route("{customerId}/orders")]
        [HttpPost]
        [ProducesResponseType(typeof(Guid), (int)HttpStatusCode.Created)]
        public async Task<IActionResult> AddCustomerOrder(
            [FromRoute] Guid customerId,
            [FromBody] CustomerOrderRequest request)
        {
            var response = await _mediator.Send(new AddOrderCommand(customerId, request.Products));
            return Created(string.Empty, response);
        }
    }
}
