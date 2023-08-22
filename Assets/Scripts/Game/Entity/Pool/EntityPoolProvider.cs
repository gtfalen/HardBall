using Game.Entity.Pool.Service;
using UnityEngine;
using Zenject;

namespace Game.Entity.Pool
{
    public class EntityPoolProvider: MonoBehaviour
    {
        [Inject] private IEntityPoolService _entityPoolService;
        
        public static EntityPoolProvider Instance;
        public IEntityPoolService EntityPoolService { get; }

        public EntityPoolProvider(IEntityPoolService entityPoolService) => EntityPoolService = entityPoolService;
        private void Awake() => Instance = new(_entityPoolService);
    }
}