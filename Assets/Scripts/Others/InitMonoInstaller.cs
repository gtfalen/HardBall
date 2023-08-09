using Zenject;

namespace Others
{
    public class InitMonoInstaller: MonoInstaller
    {
        public override void InstallBindings()
        {
            BindFirst();
            BindSettings();
            BindServices();
            BindPresenters();
            BindLast();
        }
        
        protected virtual void BindFirst() {}
        protected virtual void BindSettings() {}
        protected virtual void BindServices() {}
        protected virtual void BindPresenters() {}
        protected virtual void BindLast() {}
    }
}