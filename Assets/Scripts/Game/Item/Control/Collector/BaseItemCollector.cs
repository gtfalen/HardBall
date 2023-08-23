using UnityEngine;

namespace Game.Item
{
    public class BaseItemCollector: MonoBehaviour
    {
        [Header("Pickup Delay")] 
        [SerializeField] [Range(0.1f, 10f)] private float _collectorCooldown = 0.4f;
        
        [Header("is it allowed to collect items")] 
        [SerializeField] private bool _isAllAllowedPick = true;

        public bool IsAllAllowedPick { get; protected set; } = true;
        public float CollectorCooldown { get; set; }
        private ItemDistributorView _itemDistributorView;

        public void Start()
        {
            CollectorCooldown = _collectorCooldown;
            IsAllAllowedPick = _isAllAllowedPick;
        }

        public void SetDistributor(ItemDistributorView itemDistributorView)
        {
            _itemDistributorView = itemDistributorView;
            InvokeRepeating(nameof(CollectItem), CollectorCooldown, CollectorCooldown);
        }

        public void UnsetDistributor()
        {
            _itemDistributorView = null;
            CancelInvoke(nameof(CollectItem));
        }

        public void CollectItem()
        {
            if(!IsAllAllowedPick)
                return;

            OnCollectItem(_itemDistributorView);
        }

        protected virtual void OnCollectItem(ItemDistributorView itemDistributorView) {}
    }
}