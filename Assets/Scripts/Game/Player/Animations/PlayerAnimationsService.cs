using Game.Input;
using Game.Player.Spawner;
using StateMachine.States;
using Zenject;

namespace Game.Player.Animations
{
    public class PlayerAnimationsService: IPlayerAnimationsService, IInitializable
    {
        private readonly IPlayerSpawnService _playerSpawnService;
        private readonly IMovableInputHandler _movableInputHandler;
        public bool IsEnable { get; set; }

        public PlayerAnimationsService
        (
            IPlayerSpawnService playerSpawnService,
            IMovableInputHandler movableInputHandler
        )
        {
            _playerSpawnService = playerSpawnService;
            _movableInputHandler = movableInputHandler;
        }

        public void Initialize()
        {
            _movableInputHandler.StartMove += OnStartMove;
            _movableInputHandler.StopMove += OnStopMove;
        }

        private void OnStartMove()
        {
            if(!IfValid())
                return;

            _playerSpawnService.CurrentPlayerView.stateMachineController.TryRunState<RunState>();
        }

        private void OnStopMove()
        {
            if(!IfValid())
                return;
            
            _playerSpawnService.CurrentPlayerView.stateMachineController.TryRunState<IdleState>();
        }

        private bool IfValid() => _playerSpawnService.IsSpawn.Value || IsEnable;
    }
}