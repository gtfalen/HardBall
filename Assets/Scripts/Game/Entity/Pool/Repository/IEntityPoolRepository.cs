using System;

namespace Game.Entity.Repository
{
    public interface IEntityPoolRepository
    {
        bool HasOriginalPrefab(Type type);
        bool TryGetOriginalPrefab(Type type, out BaseEntity baseEntity);
        bool TryCreateEntityType(Type type, BaseEntity prefab);
        bool TryAddEntity(Type type, BaseEntity view);
        bool TryGetFreeEntity(Type type, out BaseEntity baseEntity);
    }
}