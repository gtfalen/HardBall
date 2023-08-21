using Zenject;

namespace Others
{
    public class InitMonoInstaller: MonoInstaller
    {
        public override void InstallBindings()
        {
            BindFirst();
            BindHandlers();
            BindSettings();
            BindServices();
            BindPresenters();
            BindScenario();
            BindLast();
        }
        
        protected virtual void BindFirst() {}
        protected virtual void BindHandlers() {}
        protected virtual void BindSettings() {}
        protected virtual void BindServices() {}
        protected virtual void BindPresenters() {}
        protected virtual void BindScenario() {}
        protected virtual void BindLast() {}
    }
}