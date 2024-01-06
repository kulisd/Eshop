using Eshop.Domain.SeedWork;

namespace Eshop.Domain.Orders.Events
{
    public class OrderAddedEvent : DomainEventBase
    {
        public Guid OrderId { get; }

        public Guid CustomerId { get; }

        public OrderAddedEvent(Guid orderId, Guid customerId)
        {
            OrderId = orderId;
            CustomerId = customerId;
        }
    }
}
