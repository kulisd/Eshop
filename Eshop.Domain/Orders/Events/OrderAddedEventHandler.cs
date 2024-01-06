using Eshop.Domain.Orders.Events;
using MediatR;

internal class OrderAddedEventHandler : INotificationHandler<OrderAddedEvent>
{
    public Task Handle(OrderAddedEvent notification, CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}
