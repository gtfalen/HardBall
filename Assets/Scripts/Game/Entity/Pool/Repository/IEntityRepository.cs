using System;
using System.Collections.Generic;

namespace Game.Entity.Repository
{
    public interface IEntityRepository
    {
        Action<BaseEntity> OnSpawn { get; set; }
        Action<BaseEntity> OnDeSpawn { get; set; }

        bool TryAdd(BaseEntity entity);
        bool TryRemove(BaseEntity entity);
        bool Has(BaseEntity entity);
        
        IEnumerable<BaseEntity> GetAll();
    }
}