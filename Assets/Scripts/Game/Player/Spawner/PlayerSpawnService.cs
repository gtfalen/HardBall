using System;
using Game.Entity;
using Game.Entity.Pool.Service;
using Game.SessionScenarios;

namespace Game.Player.Spawner
{
    public class PlayerSpawnService: IPlayerSpawnService
    {
        private readonly IEntityPoolService _entityPoolService;
        private readonly CoreGamePlayModel _coreGamePlayModel;

        public Action<PlayerView> OnPlayerSpawn { get; set; }
        public Action OnPlayerDeSpawn { get; set; }
        public bool IsSpawn { get; private set; }

        private BaseEntity _spawnedEntity;
        private PlayerView _playerView;

        public PlayerSpawnService
        (
            IEntityPoolService entityPoolService,
            CoreGamePlayModel coreGamePlayModel
        )
        {
            _entityPoolService = entityPoolService;
            _coreGamePlayModel = coreGamePlayModel;
        }
        
        public bool TryGetBaseEntity(out BaseEntity playerEntity)
        {
            playerEntity = _spawnedEntity;
            return IsSpawn;
        }

        public bool TryGetPlayerView(out PlayerView playerView)
        {
            playerView = _playerView;
            return IsSpawn;
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

            var playerView = (PlayerView)playerEntity;
            
            _spawnedEntity = playerEntity;
            _playerView = playerView;
            IsSpawn = isSpawned;
            OnPlayerSpawn?.Invoke(playerView);
            return isSpawned;
        }

        public bool TryDeSpawn()
        {
            if (!IsSpawn) 
                return false;
            
            var isDeSpawned = _entityPoolService.TryDeSpawn(_spawnedEntity);
            IsSpawn = !isDeSpawned;
            OnPlayerDeSpawn?.Invoke();
            return isDeSpawned;
        }
    }
}