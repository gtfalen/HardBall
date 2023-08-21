using System;
using UnityEngine;

namespace Game.Entity.Pool.Service
{
    public interface IEntityPoolService
    {
        bool TryRegister(BaseEntity entity);
        
        bool TrySpawn(Type type, Vector3 position, Quaternion rotation, out BaseEntity baseEntity);
        bool TryDeSpawn(BaseEntity baseEntity);
    }
}