using Others;

namespace Input
{
    public class InputInstaller: InitMonoInstaller
    {
        protected override void BindFirst()
        {
            Container.Bind<InputActions>().AsSingle();
            Container.Resolve<InputActions>().Enable();
        }
    }
}