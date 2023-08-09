using Others;

namespace UI
{
    public class UIControlInstaller: InitMonoInstaller
    {
        protected override void BindServices()
        {
            Container.BindInterfacesTo<UIControlService>().AsSingle();
        }
    }
}