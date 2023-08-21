using System;
using System.Collections.Generic;

namespace Game.Entity.Repository
{
    public class EntityRepository: IEntityRepository
    {
        private List<BaseEntity> _spawnedEntity = new();
        
        public Action<BaseEntity> OnSpawn { get; set; }
        public Action<BaseEntity> OnDeSpawn { get; set; }
        
        public bool Has(BaseEntity entity) => _spawnedEntity.Contains(entity);

        public IEnumerable<BaseEntity> GetAll() => _spawnedEntity.ToArray();

        public bool TryAdd(BaseEntity entity)
        {
            if (_spawnedEntity.Contains(entity))
                return false;
            
            _spawnedEntity.Add(entity);
            OnSpawn?.Invoke(entity);
            return true;
        }

        public bool TryRemove(BaseEntity entity)
        {
            if (!_spawnedEntity.Contains(entity))
                return false;
            
            OnDeSpawn?.Invoke(entity);
            _spawnedEntity.Remove(entity);
            return true;
        }
    }
}