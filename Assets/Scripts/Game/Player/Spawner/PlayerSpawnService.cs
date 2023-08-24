using System;
using Game.Entity;
using Game.Entity.Pool.Service;
using Game.SessionScenarios;
using UniRx;

namespace Game.Player.Spawner
{
    public class PlayerSpawnService: IPlayerSpawnService
    {
        private readonly IEntityPoolService _entityPoolService;
        private readonly CoreGamePlayModel _coreGamePlayModel;

        public Action<PlayerView> OnPlayerSpawn { get; set; }
        public Action OnPlayerDeSpawn { get; set; }
        
        public PlayerView CurrentPlayerView { get; private set; }
        public ReactiveProperty<bool> IsSpawn { get; } = new();

        private BaseEntity _spawnedEntity;

        public PlayerSpawnService
        (
            IEntityPoolService entityPoolService,
            CoreGamePlayModel coreGamePlayModel
        )
        {
            _entityPoolService = entityPoolService;
            _coreGamePlayModel = coreGamePlayModel;
        }

        public bool TrySpawn(out BaseEntity playerEntity)
        {
            var isSpawned = _entityPoolService.TrySpawn
            (
                typeof(PlayerView),
                _coreGamePlayModel.PlayerSpawnTransform.position,
                _coreGamePlayModel.PlayerSpawnTransform.rotation,
                out playerEntity
            );

            CurrentPlayerView = (PlayerView)playerEntity;
            _spawnedEntity = playerEntity;
            IsSpawn.Value = isSpawned;
            OnPlayerSpawn?.Invoke(CurrentPlayerView);
            return isSpawned;
        }

        public bool TryDeSpawn()
        {
            if (!IsSpawn.Value) 
                return false;
            
            var isDeSpawned = _entityPoolService.TryDeSpawn(_spawnedEntity);
            IsSpawn.Value = !isDeSpawned;
            OnPlayerDeSpawn?.Invoke();
            CurrentPlayerView = null;
            return isDeSpawned;
        }
    }
}