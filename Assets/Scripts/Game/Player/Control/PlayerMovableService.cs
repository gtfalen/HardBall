using System;
using Game.Input;
using Game.Player.Spawner;
using Game.SessionScenarios;
using UniRx;
using UnityEngine;
using Zenject;

namespace Game.Player.Control
{
    public class PlayerMovableService: IPlayerMovableService, IInitializable, IDisposable
    {
        private readonly IPlayerSpawnService _playerSpawnService;
        private readonly IMovableInputHandler _movableInputHandler;
        private readonly CoreGamePlayModel _coreGamePlayModel;
        private readonly CompositeDisposable _compositeDisposable = new();

        public bool IsEnable { get; set; } = true;
        private PlayerView _playerView;

        public PlayerMovableService
        (
            IPlayerSpawnService playerSpawnService,
            IMovableInputHandler movableInputHandler,
            CoreGamePlayModel coreGamePlayModel
        )
        {
            _playerSpawnService = playerSpawnService;
            _movableInputHandler = movableInputHandler;
            _coreGamePlayModel = coreGamePlayModel;
        }

        public void Initialize()
        {
            _movableInputHandler.Move += OnMove;
            _playerSpawnService.OnPlayerSpawn += (playerView) =>
            {
                _movableInputHandler.Move += OnMove;
                _playerView = playerView;
            };
            _playerSpawnService.OnPlayerDeSpawn += () => { _movableInputHandler.Move -= OnMove; };
        }

        public void Dispose() => _compositeDisposable?.Dispose();

        private void OnMove(Vector2 direction)
        {
            if(!IsEnable)
                return;

            var playerDirection = new Vector3(direction.x, 0, direction.y);
            var playerSpeed = _coreGamePlayModel.DefaultPlayerSpeed * Time.deltaTime;
            var playerGravity = Physics.gravity * Time.deltaTime;

            _playerView.CharacterController.Move(playerDirection * playerSpeed + playerGravity);
            _playerView.SkinTransform.rotation = Quaternion.Lerp(_playerView.SkinTransform.rotation,
                Quaternion.LookRotation(playerDirection), Time.deltaTime * 10);
        }

    }
}