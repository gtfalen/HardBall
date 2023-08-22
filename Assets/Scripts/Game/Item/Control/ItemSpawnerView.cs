using System;
using Game.Entity.Pool;
using Game.Entity.Pool.Service;
using UnityEngine;

namespace Game.Item
{
    public class ItemSpawnerView: MonoBehaviour
    {
        [Header("The prefab of the item that will spawn")]
        [SerializeField] private ItemView _itemPrefab;
        
        [Header("Item spawn transform")]
        [SerializeField] private Transform _itemSpawnTransform;

        [Header("Repository where items will spawn")]
        [SerializeField] private ItemRepositoryView _itemRepositoryView;

        private IEntityPoolService _entityPoolService;
        private void Start() => _entityPoolService = EntityPoolProvider.Instance.EntityPoolService;

        public void SpawnItem()
        {
            if (_itemPrefab == null)
                throw new ArgumentNullException("Spawn item prefab not set");
            
            if (_itemRepositoryView == null)
                throw new ArgumentNullException("Item repository not set");

            if (_itemSpawnTransform == null)
                throw new ArgumentNullException("Item spawn transform not set");
            
            if(!_itemRepositoryView.IsFreeSpace())
                return;
            
            if (_entityPoolService.TrySpawn
            (
                _itemPrefab.GetType(),
                _itemSpawnTransform.position,
                _itemSpawnTransform.rotation,
                out var addedItem
            )) _itemRepositoryView.TryAdd(addedItem);
        }
    }
}