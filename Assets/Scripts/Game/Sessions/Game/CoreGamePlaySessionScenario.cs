using Game.Player;
using MainMenu.View;
using Zenject;

namespace Game.SessionScenarios
{
    public class CoreGamePlaySessionScenario: IInitializable
    {
        private readonly IPlayerService _playerService;
        private readonly IHudViewPresenter _hudViewPresenter;

        public CoreGamePlaySessionScenario
        (
            IPlayerService playerService,
            IHudViewPresenter hudViewPresenter
        )
        {
            _playerService = playerService;
            _hudViewPresenter = hudViewPresenter;
        }
        
        public void Initialize()
        {
            _playerService.TrySpawn();
            _hudViewPresenter.Show();
        }
    }
}