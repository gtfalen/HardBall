using Game.Player.Control;
using Game.Player.Spawner;
using Others;

namespace Game.Player
{
    public class PlayerInstaller: InitMonoInstaller
    {
        protected override void BindServices()
        {
            Container.BindInterfacesTo<PlayerMovableService>().AsSingle();
            Container.BindInterfacesTo<PlayerSpawnService>().AsSingle();
            Container.BindInterfacesTo<PlayerService>().AsSingle();
        }
    }
}