using Eshop.Application.Orders.CustomerOrder.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Ardalis.GuardClauses;
using Eshop.API.Examples;
using Eshop.Contracts;
using Eshop.Contracts.Shared;
using Swashbuckle.AspNetCore.Filters;

namespace Eshop.API.Controllers;

[ApiController]
[Route("api/v1/customers")]
public class CustomerOrderController(ISender sender) : ControllerBase
{
    private readonly ISender _sender = Guard.Against.Null(sender, nameof(sender));

    /// <summary>
    /// Adds a new order for a specified customer.
    /// </summary>
    /// <param name="customerId">The unique identifier of the customer.</param>
    /// <param name="request">The request containing the list of products to be ordered.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>A newly created order ID.</returns>
    [Route("{customerId:guid}/orders")]
    [HttpPost]
    [ProducesResponseType(typeof(Guid), (int)HttpStatusCode.Created)]
    [ProducesResponseType(typeof(ErrorDto), (int)HttpStatusCode.BadGateway)]
    [SwaggerRequestExample(typeof(CustomerOrderRequest), typeof(CustomerOrderRequestExample))]
    [SwaggerResponseExample((int)HttpStatusCode.BadGateway, typeof(ErrorDtoExample))]
    public async Task<IActionResult> AddCustomerOrder(
        [FromRoute] Guid customerId,
        [FromBody] CustomerOrderRequest request,
        CancellationToken cancellationToken = default)
    {
        var orderId = await _sender.Send(new AddOrderCommand(customerId, request.Products), cancellationToken);
        // TODO: Implement the response.
        // return Created($"/api/v1/customers/{customerId}/orders/{orderId}", orderId);
        return Created(string.Empty, orderId);
    }
}