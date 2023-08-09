using UI;
using UnityEngine;
using Zenject;

namespace Settings
{
    [CreateAssetMenu(fileName = "AppSettingsInstaller", menuName = "SettingsInstallers/AppSettingsInstaller", order = 0)]
    public class AppSettingsInstaller: ScriptableObjectInstaller
    {
        [SerializeField] private UIPrefabs _uiPrefabs;
        
        public override void InstallBindings()
        {
            Container.BindInstance<IUIPrefabs>(_uiPrefabs);
        }
    }
}