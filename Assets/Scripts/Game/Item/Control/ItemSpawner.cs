using System;
using Game.Entity;
using Game.Entity.Pool;
using Game.Entity.Pool.Service;
using UnityEngine;

namespace Game.Item
{
    public class ItemSpawner: MonoBehaviour
    {
        [Header("The prefab of the item that will spawn")]
        [SerializeField] private ItemView _itemPrefab;
        
        [Header("Item spawn transform")]
        [SerializeField] private Transform _itemSpawnTransform;

        [Header("Repository where items will spawn")]
        [SerializeField] private ItemRepository _itemRepository;

        private IEntityPoolService _entityPoolService;

        public Action<BaseEntity> OnSpawnItem { get; set; }

        private void Start()
        {
            if (_itemPrefab == null)
                throw new ArgumentNullException("Spawn item prefab not set");
            
            if (_itemRepository == null)
                throw new ArgumentNullException("Item repository not set");

            if (_itemSpawnTransform == null)
                throw new ArgumentNullException("Item spawn transform not set");
            
            _entityPoolService = EntityPoolProvider.Instance.EntityPoolService;
        }

        public void SpawnItem() => TrySpawnItem();
        
        public bool TrySpawnItem()
        {
            if(!_itemRepository.IsFreeSpace())
                return false;
            
            if (!_entityPoolService.TrySpawn
            (
                _itemPrefab.GetType(),
                _itemSpawnTransform.position,
                _itemSpawnTransform.rotation,
                out var addedItem
            )) return false;
            
            _itemRepository.TryAddItem(addedItem);
            OnSpawnItem?.Invoke(addedItem);
            return true;
        }

        public bool IsPossibleSpawn() => _itemRepository.IsFreeSpace();
    }
}