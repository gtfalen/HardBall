using Others;
using UnityEngine;

namespace Game.SessionScenarios
{
    public class GameSessionInstaller: InitMonoInstaller
    {
        [SerializeField] private CoreGamePlayModel _coreGameplayModel;

        protected override void BindScenarios()
        {
            Container.BindInterfacesTo<CoreGamePlaySessionScenario>().AsSingle();
        }

        protected override void BindOthers()
        {
            Container.BindInstance(_coreGameplayModel).AsSingle();
        }
    }
}