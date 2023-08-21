using Game.Entity.Pool.Service;
using Game.Entity.Repository;
using Others;

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
    }
}