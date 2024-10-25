using Eshop.Domain.SeedWork;

namespace Eshop.Application.Configuration;

public class DomainEventBase : IDomainEvent
{
    public DateTime OccurredOn { get; } = DateTime.Now;
}