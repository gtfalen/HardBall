using System;
using UnityEngine;

namespace Game.Item
{
    public class ItemPlayerCollectorView: BaseItemCollector
    {
        [Header("Player repository")] 
        [SerializeField] private ItemRepository _itemRepository;

        protected override void OnStart()
        {
            if (_itemRepository == null)
                throw new ArgumentNullException("Item repository not set");
        }

        protected override void OnCollectItem(ItemRepository collectedRepository)
        {
            if(!_itemRepository.IsFreeSpace())
                return;

            if (collectedRepository.TryGetItem(out var receivedItem))
                _itemRepository.TryAddItem(receivedItem);
        }
    }
}