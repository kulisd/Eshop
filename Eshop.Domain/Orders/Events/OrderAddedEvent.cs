using Eshop.Domain.SeedWork;

namespace Eshop.Domain.Orders.Events;

public class OrderAddedEvent(Guid orderId, Guid customerId) : DomainEventBase
{
    public Guid OrderId { get; } = orderId;

    public Guid CustomerId { get; } = customerId;
}