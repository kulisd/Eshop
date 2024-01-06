using Eshop.Domain.SeedWork;
using MediatR;

internal class DomainEventsDispatcher : IDomainEventsDispatcher
{
    private readonly IMediator _mediator;

    public DomainEventsDispatcher(IMediator mediator)
    {
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
    }

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
