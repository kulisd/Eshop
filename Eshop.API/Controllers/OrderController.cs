using Eshop.Application.Orders.CustomerOrder.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Ardalis.GuardClauses;
using Eshop.Contracts.Shared;

namespace Eshop.API.Controllers;

[ApiController]
[Route("api/v1/orders")]
public class OrderController(ISender sender) : ControllerBase
{
    private readonly ISender _sender = Guard.Against.Null(sender, nameof(sender));
        
    /// <summary>
    /// Retrieves the details of a specific order.
    /// </summary>
    /// <param name="orderId">The unique identifier of the order.</param>
    /// <returns>The details of the specified order.</returns>
    [Route("{orderId:guid}")]
    [HttpGet]
    [ProducesResponseType(typeof(OrderDto), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(ErrorDto), (int)HttpStatusCode.BadGateway)]
    public async Task<IActionResult> GetCustomerOrderDetails([FromRoute] Guid orderId)
    {
        var orderDetails = await _sender.Send(new GetOrderQuery(orderId));
        return Ok(orderDetails);
    }
}