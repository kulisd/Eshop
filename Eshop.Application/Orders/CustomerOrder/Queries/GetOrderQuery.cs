using Eshop.Application.Configuration.Queries;
using Eshop.Contracts.Shared;

namespace Eshop.Application.Orders.CustomerOrder.Queries;

public class GetOrderQuery(Guid orderId, Guid customerId) : IQuery<OrderDto>
{
    public Guid OrderId { get; } = orderId;
    public Guid CustomerId { get; } = customerId;
}