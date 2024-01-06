using Eshop.Application.Orders.CustomerOrder.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Eshop.API.Controllers
{
    [Route("api/v1/customers")]
    [ApiController]
    public class CustomerController : Controller
    {
        private readonly IMediator _mediator;

        public CustomerController(IMediator mediator)
        {
            _mediator = mediator;
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
