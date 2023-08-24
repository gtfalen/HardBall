using UnityEngine;

namespace Game.Item
{
    public class BaseItemCollector: MonoBehaviour
    {
        [Header("Pickup Delay")] 
        [SerializeField] [Range(0.1f, 10f)] private float _collectorCooldown = 0.4f;
        
        [Header("Is it allowed to collect items")] 
        [SerializeField] private bool _isAllAllowedPick = true;

        public bool IsAllAllowedPick { get; protected set; } = true;
        public float CollectorCooldown { get; set; }
        
        private ItemRepository _collectedRepository;

        public void Start()
        {
            CollectorCooldown = _collectorCooldown;
            IsAllAllowedPick = _isAllAllowedPick;
            OnStart();
        }

        public void SetCollectedRepository(ItemRepository collectedRepository)
        {
            _collectedRepository = collectedRepository;
            InvokeRepeating(nameof(CollectItem), CollectorCooldown, CollectorCooldown);
        }

        public void UnsetCollectedRepository()
        {
            _collectedRepository = null;
            CancelInvoke(nameof(CollectItem));
        }

        public void CollectItem()
        {
            if(!IsAllAllowedPick)
                return;
                
            OnCollectItem(_collectedRepository);
        }

        protected virtual void OnCollectItem(ItemRepository collectedRepository) {}
        protected virtual void OnStart() {}
    }
}