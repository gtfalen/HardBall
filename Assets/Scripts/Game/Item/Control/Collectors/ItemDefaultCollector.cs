using System;
using UnityEngine;

namespace Game.Item
{
    public class ItemDefaultCollector: BaseItemCollector
    {
        [Header("Item repository")] 
        [SerializeField] private ItemRepository _itemRepository;
        
        [Header("Collected Item")] 
        [SerializeField] private ItemView _collectedItem;

        protected override void OnStart()
        {
            if (_itemRepository == null)
                throw new ArgumentNullException("Item repository not set");
            
            if (_itemRepository == null)
                throw new ArgumentNullException("Collectable item on set");
        }

        protected override void OnCollectItem(ItemRepository collectedRepository)
        {
            if(!_itemRepository.IsFreeSpace())
                return;
            
            if (collectedRepository.TryGetItem(_collectedItem, out var receivedItem))
                _itemRepository.TryAddItem(receivedItem);
        }
    }
}