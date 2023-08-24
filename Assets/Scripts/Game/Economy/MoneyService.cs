using System;
using Game.Player.Spawner;
using UniRx;
using Zenject;

namespace Game.Economy
{
    public class MoneyService: IInitializable, IDisposable, IMoneyService
    {
        private readonly IPlayerSpawnService _playerSpawnService;
        public ReactiveProperty<int> Money { get; } = new();

        private CompositeDisposable _compositeDisposable = new();

        public MoneyService
        (
            IPlayerSpawnService playerSpawnService
        )
        {
            _playerSpawnService = playerSpawnService;
        }

        public void Initialize()
        {
            _playerSpawnService.IsSpawn.Subscribe((isSpawn) =>
            {
                if (isSpawn)
                    _playerSpawnService.CurrentPlayerView.OnMoneyCollect += () => Add(1);
            })
            .AddTo(_compositeDisposable);
        }

        public void Dispose() => _compositeDisposable?.Dispose();

        public void Add(int quantity) => Money.Value += quantity;
    }
}