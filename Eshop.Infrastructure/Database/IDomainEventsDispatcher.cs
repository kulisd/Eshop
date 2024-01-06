using Eshop.Domain.SeedWork;

internal interface IDomainEventsDispatcher
{
    Task DispatchEventsAsync(IEnumerable<Entity> entities);
}
