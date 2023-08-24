using System;
using UnityEngine;

namespace Game.Item
{
    public class ItemDistributor: MonoBehaviour
    {
        [Header("Repository where items will spawn")]
        [SerializeField] private ItemRepository _itemRepository;

        [Header("The layer to which the dispenser reacts")]
        [SerializeField] private LayerMask _layerInteractions;
        
        private void Start()
        {
            if (_itemRepository == null)
                throw new ArgumentNullException("Item repository not set");
        }

        public void OnTriggerEnter(Collider other)
        {
            if(IsValidCollider(other))
                return;
            
            if(other.gameObject.TryGetComponent(out BaseItemCollector baseItemCollector))
                baseItemCollector.SetCollectedRepository(_itemRepository);
        }

        public void OnTriggerExit(Collider other)
        {
            if(IsValidCollider(other))
                return;

            if(other.gameObject.TryGetComponent(out BaseItemCollector baseItemCollector))
                baseItemCollector.UnsetCollectedRepository();
        }

        private bool IsValidCollider(Collider other) =>
            !((_layerInteractions & 1 << other.gameObject.layer) == 1 << other.gameObject.layer);
    }
}