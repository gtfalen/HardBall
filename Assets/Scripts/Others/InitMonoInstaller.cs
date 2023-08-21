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
            BindRepository();
            BindPresenters();
            BindScenarios();
            BindOthers();
            BindLast();
        }
        
        protected virtual void BindFirst() {}
        protected virtual void BindHandlers() {}
        protected virtual void BindSettings() {}
        protected virtual void BindServices() {}
        protected virtual void BindRepository() {}
        protected virtual void BindPresenters() {}
        protected virtual void BindScenarios() {}
        protected virtual void BindOthers() {}
        protected virtual void BindLast() {}
    }
}