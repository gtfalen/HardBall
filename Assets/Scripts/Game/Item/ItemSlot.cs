using System;
using DG.Tweening;
using Game.Entity;
using UnityEngine;

namespace Game.Item
{
    public class ItemSlot: MonoBehaviour
    {
        [Header("Transform where the object will be")] 
        [SerializeField] private Transform _slotTransform;

        public bool IsEmpty { get; private set; } = true;
        public BaseEntity ItemInSlot { get; private set; }
        
        private void Start()
        {
            if (_slotTransform == null)
                throw new ArgumentNullException("The item location transform is not set");
        }

        public bool TrySetItem(BaseEntity item)
        {
            if (!IsEmpty)
                return false;
            
            ItemInSlot = item;
            IsEmpty = false;
            ItemInSlot.transform.SetParent(_slotTransform);
            AnimationSetItemSlot(ItemInSlot);
            return true;
        }

        public void UnSetItem()
        {
            IsEmpty = true;
            ItemInSlot = null;
        }

        private void AnimationSetItemSlot(BaseEntity item)
        {
            item.transform
                .DOLocalMove(Vector3.zero, 0.1f)
                .SetEase(Ease.Flash)
                .SetLink(gameObject);

            item.transform
                .DOLocalRotate(Vector3.zero, 0.1f)
                .SetEase(Ease.Flash)
                .SetLink(gameObject);
        }
    }
}