using MediatR;

namespace Eshop.Domain.Orders.Events;

internal class OrderAddedEventHandler : INotificationHandler<OrderAddedEvent>
{
    public Task Handle(OrderAddedEvent notification, CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}