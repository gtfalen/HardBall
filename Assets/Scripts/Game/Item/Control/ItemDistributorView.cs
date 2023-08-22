using System;
using Game.Entity;
using UnityEngine;

namespace Game.Item
{
    public class ItemDistributorView: MonoBehaviour
    {
        [Header("Repository where items will spawn")]
        [SerializeField] private ItemRepositoryView _itemRepositoryView;

        private void Start()
        {
            if (_itemRepositoryView == null)
                throw new ArgumentNullException("Item repository not set");
        }

        public void OnTriggerEnter(Collider other)
        {
            if(other.gameObject.TryGetComponent(out BaseItemCollector baseItemCollector))
                baseItemCollector.SetDistributor(this);
        }

        public void OnTriggerExit(Collider other)
        {
            if(other.gameObject.TryGetComponent(out BaseItemCollector baseItemCollector))
                baseItemCollector.UnsetDistributor();
        }

        public bool TryGetItem(out BaseEntity item) => _itemRepositoryView.TryGet(out item);
    }
}