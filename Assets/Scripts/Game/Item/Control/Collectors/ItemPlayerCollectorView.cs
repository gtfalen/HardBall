using System;
using Game.Player;
using UnityEngine;

namespace Game.Item
{
    public class ItemPlayerCollectorView: BaseItemCollector
    {
        [Header("Player repository")] 
        [SerializeField] private ItemRepository _itemRepository;
        
        [Header("Player view")] 
        [SerializeField] private PlayerView _playerView;

        protected override void OnStart()
        {
            if (_itemRepository == null)
                throw new ArgumentNullException("Item repository not set");
            
            if (_playerView == null)
                throw new ArgumentNullException("PlayerView not set");
        }

        protected override void OnCollectItem(ItemRepository collectedRepository)
        {
            if (collectedRepository.TryGetItem<ItemMoneyView>(out var money))
            {
                money.Destroy();
                _playerView.OnMoneyCollect?.Invoke();
                return;
            }

            if(!_itemRepository.IsFreeSpace())
                return;

            if (collectedRepository.TryGetItem(out var receivedItem))
                _itemRepository.TryAddItem(receivedItem);
        }
    }
}