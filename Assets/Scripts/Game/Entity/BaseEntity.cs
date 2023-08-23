using Game.Entity.Pool;
using UnityEngine;

namespace Game.Entity
{
    public class BaseEntity: MonoBehaviour
    {
        public void Destroy() => EntityPoolProvider.Instance.EntityPoolService.TryDeSpawn(this);
    }
}