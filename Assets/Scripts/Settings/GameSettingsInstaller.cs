using Game.Entity.Settings;
using UnityEngine;
using Zenject;

namespace Settings
{
    [CreateAssetMenu(fileName = "GameSettingsInstaller", menuName = "SettingsInstallers/GameSettingsInstaller", order = 0)]
    public class GameSettingsInstaller: ScriptableObjectInstaller
    {
        [SerializeField] private EntityPoolSettings entityPoolSettings;
        
        public override void InstallBindings()
        {
            Container.BindInstance<IEntitySettingsPoolProvider>(entityPoolSettings);
        }
    }
}