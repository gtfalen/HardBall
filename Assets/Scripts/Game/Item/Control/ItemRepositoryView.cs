using System;
using System.Collections.Generic;
using DG.Tweening;
using Game.Entity;
using ModestTree;
using UnityEngine;

namespace Game.Item
{
    public class ItemRepositoryView: MonoBehaviour
    {
        [Header("Item spawn slots")]
        [SerializeField] private List<Transform> _slots;

        [Header("Initial maximum available slots")] 
        [SerializeField] [Range(1, 99)] private int _maxAvailableSlots;

        private List<BaseEntity> _itemRepository = new();

        public Action<BaseEntity> OnAddedItem { get; set; }
        public Action<BaseEntity> OnGetItem { get; set; }

        public bool IsFreeSpace() 
            => _itemRepository.Count != _maxAvailableSlots && _itemRepository.Count != _slots.Count;
        
        public bool TryAdd(BaseEntity addedItem)
        {
            if (!IsFreeSpace())
                return false;
            
            SetSlot(_slots[_itemRepository.Count], addedItem.transform);
            _itemRepository.Add(addedItem);
            OnAddedItem?.Invoke(addedItem);
            return true;
        }

        public bool TryGet(out BaseEntity receivedItem)
        {
            receivedItem = default;
            if (_itemRepository.IsEmpty())
                return false;

            receivedItem = _itemRepository[^1];
            _itemRepository.Remove(receivedItem);
            OnGetItem?.Invoke(receivedItem);
            return true;
        }

        public bool TryGet<T>(T requiredItem, out BaseEntity receivedItem) where T : BaseEntity
        {
            var searchType = requiredItem.GetType();
            receivedItem = _itemRepository.Find(item => item.GetType() == searchType);
            if (receivedItem == null)
                return false;
            
            _itemRepository.Remove(receivedItem);
            OnGetItem?.Invoke(receivedItem);
            return true;
        }

        public bool HasItem<T>(T requiredItem)
        {
            var searchType = requiredItem.GetType();
            return _itemRepository.Find(item => item.GetType() == searchType) != null;
        }

        public IEnumerable<BaseEntity> GetAll() => _itemRepository.ToArray();

        private void SetSlot(Transform slot, Transform addedItem)
        {
            addedItem.transform.SetParent(slot);
            
            addedItem.transform
                .DOLocalMove(Vector3.zero, 0.4f)
                .SetEase(Ease.Flash)
                .SetLink(gameObject);
            
            addedItem.transform
                .DOLocalRotate(Vector3.zero, 0.4f)
                .SetEase(Ease.Flash)
                .SetLink(gameObject);
        }
    }
}