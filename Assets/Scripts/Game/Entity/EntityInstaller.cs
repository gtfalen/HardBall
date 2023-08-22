using Game.Entity.Pool;
using Game.Entity.Pool.Service;
using Game.Entity.Repository;
using Others;
using UnityEngine;

namespace Game.Entity
{
    public class EntityInstaller: InitMonoInstaller
    {
        protected override void BindServices()
        {
            Container.BindInterfacesTo<EntityPoolService>().AsSingle();
        }
        
        protected override void BindRepository()
        {
            Container.BindInterfacesTo<EntityPoolRepository>().AsSingle();
            Container.BindInterfacesTo<EntityRepository>().AsSingle();
        }

        protected override void BindOthers()
        {
            var entityPoolProvider = new GameObject("EntityPoolProvider").AddComponent<EntityPoolProvider>();
            var poolProvider = Container.InstantiatePrefabForComponent<EntityPoolProvider>
            (
                entityPoolProvider.gameObject,
                Vector3.zero, 
                Quaternion.identity,
                null
            );

            Destroy(entityPoolProvider);
            Container.BindInterfacesTo<EntityPoolProvider>().FromInstance(poolProvider);
        }
    }
}