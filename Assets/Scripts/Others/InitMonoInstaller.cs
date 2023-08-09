using Zenject;

namespace Others
{
    public class InitMonoInstaller: MonoInstaller
    {
        public override void InstallBindings()
        {
            BindFirst();
            BindSettings();
            BindLast();
        }
        
        protected virtual void BindFirst() {}
        protected virtual void BindSettings() {}
        protected virtual void BindLast() {}
    }
}