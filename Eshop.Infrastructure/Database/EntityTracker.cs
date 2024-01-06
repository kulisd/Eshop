using Eshop.Domain.SeedWork;

internal class EntityTracker : IEntityTracker
{
    private readonly List<Entity> _trackedEntities = new List<Entity>();

    public void TrackEntity(Entity entity)
    {
        _trackedEntities.Add(entity);
    }

    public IEnumerable<Entity> GetTrackedEntities() => _trackedEntities.AsReadOnly();

    public void ClearTrackedEntities() => _trackedEntities.Clear();
}