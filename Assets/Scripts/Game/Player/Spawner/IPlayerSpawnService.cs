using Game.Entity;

namespace Game.Player.Spawner
{
    public interface IPlayerSpawnService
    {
        bool IsSpawn { get; }

        bool TrySpawn(out BaseEntity playerEntity);
        bool TryDeSpawn();
    }
}