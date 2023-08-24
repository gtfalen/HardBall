using System.Collections.Generic;
using System.Linq;
using Game.Entity;
using UnityEngine;

namespace Game.Item
{
    public class ItemCreator: MonoBehaviour
    {
        [Header("Item creation time")] 
        [SerializeField] [Range(0.1f, 99f)] private float _timeCreate = 1;

        [Header("Item Spawner")] 
        [SerializeField] private ItemSpawner _itemSpawner;

        [Header("Repository where items will spawn")] 
        [SerializeField] private ItemRepository _repositoryCraftedItems;

        [Header("Storage connection")]
        [SerializeField] private List<ItemRepository> _itemRepository;

        [Header("Required Items")] 
        [SerializeField] private List<ItemView> _requiredItems;

        public float TimeCreateItem { get; set; }
        
        private bool _isProcessCreating;
        
        private void Start()
        {
            TimeCreateItem = _timeCreate;

            _repositoryCraftedItems.OnChange.AddListener(CreateItemIfPossible);
            foreach (var repository in _itemRepository)
                repository.OnChange.AddListener(CreateItemIfPossible);
        }

        private void OnDisable()
        {
            _repositoryCraftedItems.OnChange.AddListener(CreateItemIfPossible);
            foreach (var repository in _itemRepository)
                repository.OnChange.AddListener(CreateItemIfPossible);
        }

        private void CreateItemIfPossible()
        {
            if(!CheckItemAvailability() || _isProcessCreating)
                return;
            
            if(!_itemSpawner.IsPossibleSpawn())
                return;
            
            _isProcessCreating = true;
            Invoke(nameof(CreateItem), TimeCreateItem);
        }

        private void CreateItem()
        {
            if(!_itemSpawner.TrySpawnItem())
                return;

            _isProcessCreating = false;
            TakeNecessaryItems();
            CreateItemIfPossible();
        }

        private void TakeNecessaryItems()
        {
            foreach (var requiredItem in _requiredItems)
            {
                foreach (var repository in _itemRepository)
                {
                    if (repository.TryGetItem(requiredItem, out var item))
                        item.Destroy();
                }
            }
        }
        
        private bool CheckItemAvailability()
        {
            var isCreationAvailable = false;
            var allItems = new List<BaseEntity>();
            foreach (var repository in _itemRepository)
                allItems = allItems.Union(repository.GetAllItem()).ToList();

            foreach (var requiredItem in _requiredItems)
            {
                var requiredItemType = requiredItem.GetType();
                isCreationAvailable = allItems.Any(item => item.GetType() == requiredItemType);
                
                if(!isCreationAvailable)
                    break;
            }

            return isCreationAvailable;
        }
    }
}