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

        public bool IsFreeSpace() 
            => _itemRepository.Count != _maxAvailableSlots && _itemRepository.Count != _slots.Count;
        
        public bool TryAdd(BaseEntity addedItem)
        {
            if (!IsFreeSpace())
                return false;
            
            SetSlot(_slots[_itemRepository.Count], addedItem.transform);
            _itemRepository.Add(addedItem);
            return true;
        }

        public bool TryGet(out BaseEntity receivedItem)
        {
            receivedItem = default;
            if (_itemRepository.IsEmpty())
                return false;

            receivedItem = _itemRepository[^1];
            _itemRepository.Remove(receivedItem);
            return true;
        }

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