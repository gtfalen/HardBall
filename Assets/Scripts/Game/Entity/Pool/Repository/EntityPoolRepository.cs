using System;
using System.Collections.Generic;
using ModestTree;

namespace Game.Entity.Repository
{
    public class EntityPoolRepository: IEntityPoolRepository
    {
        private Dictionary<Type, Model> _models = new();

        public bool TryCreateEntityType(Type type, BaseEntity prefab)
        {
            if (_models.ContainsKey(type))
                return false;

            _models.Add(type, new Model(prefab));
            return true;
        }

        public bool HasOriginalPrefab(Type type) => _models.ContainsKey(type);

        public bool TryGetOriginalPrefab(Type type, out BaseEntity baseEntity)
        {
            baseEntity = default;
            
            if (!_models.ContainsKey(type))
                return false;

            baseEntity = _models[type].OriginalPrefab;
            return true;
        }

        public bool TryAddEntity(Type type, BaseEntity view)
        {
            if (!_models.ContainsKey(type))
                return false;

            _models[type].Entity.Enqueue(view);
            return true;
        }

        public bool TryGetFreeEntity(Type entityType, out BaseEntity baseEntity)
        {
            baseEntity = default;

            if (!_models.ContainsKey(entityType))
                return false;

            if (_models[entityType].Entity.IsEmpty())
                return false;

            baseEntity = _models[entityType].Entity.Dequeue();
            return true;
        }

        public class Model
        {
            public BaseEntity OriginalPrefab { get; }
            public Queue<BaseEntity> Entity { get; }

            public Model(BaseEntity baseEntity)
            {
                OriginalPrefab = baseEntity;
                Entity = new Queue<BaseEntity>();
            }
        }
    }
}