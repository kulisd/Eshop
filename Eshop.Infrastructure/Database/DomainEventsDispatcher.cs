using Eshop.Domain.SeedWork;
using MediatR;

namespace Eshop.Infrastructure.Database;

internal class DomainEventsDispatcher(IMediator mediator) : IDomainEventsDispatcher
{
    private readonly IMediator _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));

    public async Task DispatchEventsAsync(IEnumerable<Entity> entities)
    {
        foreach (var entity in entities)
        {
            var events = entity.DomainEvents.ToArray();
            entity.ClearDomainEvents();

            foreach (var domainEvent in events)
            {
                await _mediator.Publish(domainEvent);
            }
        }
    }
}