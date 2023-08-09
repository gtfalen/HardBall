using MainMenu.View;
using Others;

namespace MainMenu
{
    public class MainMenuInstaller: InitMonoInstaller
    {
        protected override void BindPresenters()
        {
            Container.BindInterfacesTo<MainMenuViewPresenter>().AsSingle();
        }
    }
}