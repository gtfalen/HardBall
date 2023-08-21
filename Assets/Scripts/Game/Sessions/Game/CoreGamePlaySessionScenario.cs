using Game.Player;
using Zenject;

namespace Game.SessionScenarios
{
    public class CoreGamePlaySessionScenario: IInitializable
    {
        private readonly IPlayerService _playerService;

        public CoreGamePlaySessionScenario
        (
            IPlayerService playerService    
        )
        {
            _playerService = playerService;
        }
        
        public void Initialize()
        {
            _playerService.TrySpawn();
        }
    }
}