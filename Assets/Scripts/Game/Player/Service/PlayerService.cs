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
        
        public bool TrySpawn() => _playerSpawnService.TrySpawn(out _);
        public bool TryDeSpawn() => _playerSpawnService.TryDeSpawn();
    }
}