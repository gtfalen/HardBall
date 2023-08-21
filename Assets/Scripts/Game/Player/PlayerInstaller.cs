using Game.Player.Control;
using Others;

namespace Game.Player
{
    public class PlayerInstaller: InitMonoInstaller
    {
        protected override void BindServices()
        {
            Container.BindInterfacesTo<PlayerMovableService>().AsSingle();
        }
    }
}