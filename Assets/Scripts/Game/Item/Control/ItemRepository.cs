using System;
using System.Collections.Generic;
using System.Linq;
using Game.Entity;
using UniRx;
using UnityEngine;
using UnityEngine.Events;

namespace Game.Item
{
    public class ItemRepository: MonoBehaviour
    {
        [Header("Initial maximum available slots")] 
        [SerializeField] [Range(1, 999)] private int _maxAvailableSlots;
        
        [Header("Item spawn slots")]
        [SerializeField] private List<ItemSlot> _slots;

        [Header("Called when an item is added or removed")]
        public UnityEvent OnChange;
        
        [Header("Called when an item is added")]
        public UnityEvent OnAddedItem;
        
        [Header("Called when an item is removed.")]
        public UnityEvent OnGetItem;

        public ReactiveProperty<int> MaxAvailableSlots { get; } = new();
        public ReactiveProperty<int> CountItem { get; } = new();

        private void Start() => MaxAvailableSlots.Value = _maxAvailableSlots;

        public bool TryAddItem(BaseEntity addedItem)
        {
            if(addedItem == null)
                throw new ArgumentNullException("Added item is empty");

            if (!IsFreeSpace())
                return false;
            
            if (!TryGetFreeSlot(out var itemSlot))
                return false;

            if (!itemSlot.TrySetItem(addedItem))
                return false;

            CountItem.Value++;
            OnAddedItem?.Invoke();
            OnChange?.Invoke();
            return true;
        }

        public bool TryGetItem(out BaseEntity receivedItem)
        {
            receivedItem = default;
            
            if (_slots.All(slot => slot.IsEmpty))
                return false;
            
            receivedItem = EmptySlot(_slots.Last(slot => !slot.IsEmpty));
            return true;
        }

        public bool TryGetItem<T>(T requiredItem, out BaseEntity receivedItem)
        {
            receivedItem = default;
            
            if (_slots.All(slot => slot.IsEmpty))
                return false;
            
            var searchType = requiredItem.GetType();
            var fullSlots = _slots.Where(slot => !slot.IsEmpty);

            if (!fullSlots.Any(slot => slot.ItemInSlot.GetType() == searchType))
                return false;

            receivedItem = 
                EmptySlot(fullSlots.First(slot => slot.ItemInSlot.GetType() == searchType));
            return true;
        }
        
        public bool TryGetItem<T>(out BaseEntity receivedItem)
        {
            receivedItem = default;
            
            if (_slots.All(slot => slot.IsEmpty))
                return false;
            
            var searchType = typeof(T);
            var fullSlots = _slots.Where(slot => !slot.IsEmpty);

            if (!fullSlots.Any(slot => slot.ItemInSlot.GetType() == searchType))
                return false;

            receivedItem = 
                EmptySlot(fullSlots.First(slot => slot.ItemInSlot.GetType() == searchType));
            
            return true;
        }

        public IEnumerable<BaseEntity> GetAllItem() => _slots
            .Where(slot => !slot.IsEmpty)
            .Select(slot => slot.ItemInSlot)
            .ToList();

        public bool IsFreeSpace() 
            => _slots.Any(slot => slot.IsEmpty) && MaxAvailableSlots.Value > _slots.Count(slot => !slot.IsEmpty);

        private void ArrangeSlots()
        {
            for (var slotId = 0; slotId < _slots.Count; slotId++)
            {
                if(!_slots[slotId].IsEmpty)
                    continue;
                
                for (var notEmptySlotId = slotId; notEmptySlotId < _slots.Count; notEmptySlotId++)
                {
                    if (_slots[notEmptySlotId].IsEmpty)
                        continue;
                    
                    var notEmptySlot = _slots[notEmptySlotId];
                    _slots[slotId].TrySetItem(notEmptySlot.ItemInSlot);
                    notEmptySlot.UnSetItem();
                    break;
                }
            }
        }
        
        private BaseEntity EmptySlot(ItemSlot itemSlot)
        {
            var receivedItem = itemSlot.ItemInSlot;
            itemSlot.UnSetItem();
            ArrangeSlots();
            CountItem.Value--;
            OnGetItem?.Invoke();
            OnChange?.Invoke();
            return receivedItem;
        }
        
        private bool TryGetFreeSlot(out ItemSlot itemSlot)
        {
            itemSlot = default;
            
            if (!_slots.Any(slot => slot.IsEmpty))
                return false;
            
            itemSlot = _slots.First(slot => slot.IsEmpty);
            return true;
        }
    }
}