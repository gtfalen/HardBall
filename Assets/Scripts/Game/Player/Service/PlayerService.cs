using Game.Player.Spawner;

namespace Game.Player
{
    public class PlayerService: IPlayerService
    {
        private readonly IPlayerSpawnService _playerSpawnService;
        
        public PlayerService
        (
            IPlayerSpawnService playerSpawnService    
        )
        {
            _playerSpawnService = playerSpawnService;
        }

        public bool TrySpawn()
        {
            if (!_playerSpawnService.TrySpawn(out var playerEntity))
                return false;
            
            return true;
        }

        public bool TryDeSpawn() => _playerSpawnService.TryDeSpawn();
    }
}