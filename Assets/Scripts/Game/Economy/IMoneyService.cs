using UniRx;

namespace Game.Economy
{
    public interface IMoneyService
    {
        ReactiveProperty<int> Money { get; }

        void Add(int quantity);
    }
}