using Others;

namespace Game.Economy
{
    public class EconomyInstaller: InitMonoInstaller
    {
        protected override void BindServices()
        {
            Container.BindInterfacesTo<MoneyService>().AsSingle();
        }
    }
}