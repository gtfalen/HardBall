using System;
using Game.Entity;
using UniRx;

namespace Game.Player.Spawner
{
    public interface IPlayerSpawnService
    {
        public ReactiveProperty<bool> IsSpawn { get; }

        public PlayerView CurrentPlayerView { get; }
        
        Action<PlayerView> OnPlayerSpawn { get; set; }
        Action OnPlayerDeSpawn { get; set; }

        bool TrySpawn(out BaseEntity playerEntity);
        bool TryDeSpawn();
    }
}