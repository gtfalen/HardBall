namespace Game.Player
{
    public interface IPlayerService
    {
        bool TrySpawn();
        bool TryDeSpawn();
    }
}