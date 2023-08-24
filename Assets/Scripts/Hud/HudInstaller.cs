using MainMenu.View;
using Others;

namespace MainMenu
{
    public class HudInstaller: InitMonoInstaller
    {
        protected override void BindPresenters()
        {
            Container.BindInterfacesTo<HudViewPresenter>().AsSingle();
        }
    }
}