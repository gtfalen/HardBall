using Others;

namespace Game.Input
{
    public class InputHandlersInstaller : InitMonoInstaller
    {
        protected override void BindHandlers()
        {
            Container.BindInterfacesTo<MovableInputHandler>().AsSingle();
        }
    }
}