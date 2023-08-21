using Game.Entity;
using Game.Entity.Pool.Service;
using Game.SessionScenarios;

namespace Game.Player.Spawner
{
    public class PlayerSpawnService: IPlayerSpawnService
    {
        private readonly IEntityPoolService _entityPoolService;
        private readonly CoreGamePlayModel _coreGamePlayModel;

        public bool IsSpawn { get; private set; }
        
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
            
            IsSpawn = isSpawned;
            _spawnedEntity = playerEntity;
            return isSpawned;
        }

        public bool TryDeSpawn()
        {
            if (!IsSpawn) 
                return false;
            
            var isDeSpawned = _entityPoolService.TryDeSpawn(_spawnedEntity);
            IsSpawn = !isDeSpawned;
            return isDeSpawned;
        }
    }
}