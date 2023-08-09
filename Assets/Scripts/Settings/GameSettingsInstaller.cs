using UnityEngine;
using Zenject;

namespace Settings
{
    [CreateAssetMenu(fileName = "GameSettingsInstaller", menuName = "SettingsInstallers/GameSettingsInstaller", order = 0)]
    public class GameSettingsInstaller: ScriptableObjectInstaller
    {
        public override void InstallBindings()
        {
            
        }
    }
}