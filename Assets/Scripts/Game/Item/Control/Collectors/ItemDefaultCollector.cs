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
        
        [Header("Item indicator (Optional)")] 
        [SerializeField] private ItemIndicatorView _itemIndicator;

        protected override void OnStart()
        {
            if (_itemRepository == null)
                throw new ArgumentNullException("Item repository not set");
            
            if (_itemRepository == null)
                throw new ArgumentNullException("Collectable item on set");

            if (_itemIndicator != null)
                ShowItemIndicator();
        }

        protected override void OnCollectItem(ItemRepository collectedRepository)
        {
            if(!_itemRepository.IsFreeSpace())
                return;
            
            if (collectedRepository.TryGetItem(_collectedItem, out var receivedItem))
                _itemRepository.TryAddItem(receivedItem);
        }

        private void ShowItemIndicator()
        {
            var model = new ItemIndicatorView.Model
            (
                _itemRepository.MaxAvailableSlots,
                _itemRepository.CountItem,
                _collectedItem
            );
            _itemIndicator.Show(model);
        }
    }
}