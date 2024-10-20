using Eshop.Domain.SeedWork;

namespace Eshop.Infrastructure.Database;

internal class EntityTracker : IEntityTracker
{
    private readonly List<Entity> _trackedEntities = [];

    public void Track<T>(T entity) where T : Entity
    {
        _trackedEntities.Add(entity);
    }
    
    public IReadOnlyList<Entity> Get()
    {
        return _trackedEntities;
    }
    
    public T? Find<T>(Guid id) where T : Entity
    {
        return _trackedEntities.OfType<T>().FirstOrDefault(e => e.Id == id);
    }
    
    public void Clear() => _trackedEntities.Clear();
}