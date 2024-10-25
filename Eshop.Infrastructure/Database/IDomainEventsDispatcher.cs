using Eshop.Domain.SeedWork;

namespace Eshop.Infrastructure.Database;

internal interface IDomainEventsDispatcher
{
    Task DispatchEventsAsync(IEnumerable<Entity> entities);
}