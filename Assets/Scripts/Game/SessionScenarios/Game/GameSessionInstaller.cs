using Others;

namespace Game.SessionScenarios
{
    public class GameSessionInstaller: InitMonoInstaller
    {
        protected override void BindScenario()
        {
            Container.BindInterfacesTo<GameSessionScenario>().AsSingle();
        }
    }
}