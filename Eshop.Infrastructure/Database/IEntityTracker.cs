using Eshop.Domain.SeedWork;

internal interface IEntityTracker
{
    void ClearTrackedEntities();

    IEnumerable<Entity> GetTrackedEntities();

    void TrackEntity(Entity entity);
}