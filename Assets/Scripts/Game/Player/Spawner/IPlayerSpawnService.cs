using System;
using Game.Entity;

namespace Game.Player.Spawner
{
    public interface IPlayerSpawnService
    {
        bool IsSpawn { get; }

        Action<PlayerView> OnPlayerSpawn { get; set; }
        Action OnPlayerDeSpawn { get; set; }

        bool TryGetBaseEntity(out BaseEntity playerEntity);
        bool TryGetPlayerView(out PlayerView playerView);
        
        bool TrySpawn(out BaseEntity playerEntity);
        bool TryDeSpawn();
    }
}