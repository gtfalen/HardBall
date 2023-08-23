using System.Collections.Generic;
using System.Linq;
using Game.Entity;
using UnityEngine;

namespace Game.Item
{
    public class ItemCreatorView: MonoBehaviour
    {
        [Header("Storage connection")]
        [SerializeField] private List<ItemRepositoryView> _itemRepository;
        
        [Header("Required Items")] 
        [SerializeField] private List<ItemView> _requiredItems;
        
        [Header("Item Spawner")] 
        [SerializeField] private ItemSpawnerView _itemSpawnerView;

        [Header("Item creation time")] 
        [SerializeField] [Range(0.1f, 99f)] private float _timeCreate = 1;

        public float TimeCreateItem { get; set; }
        
        private bool _isStartProcessCreating;
        
        private void Start()
        {
            _itemSpawnerView.OnFreeSpace += CreateItemIfNeeded;
            TimeCreateItem = _timeCreate;
            foreach (var repository in _itemRepository)
                repository.OnAddedItem += OnAddItem;
        }

        private void OnAddItem(BaseEntity addedItem) => CreateItemIfNeeded();

        private void CreateItemIfNeeded()
        {
            if(!CheckItemAvailability() || _isStartProcessCreating)
                return;
            
            if(!_itemSpawnerView.IsPossibleSpawn())
                return;
            
            _isStartProcessCreating = true;
            Invoke(nameof(CreateItem), TimeCreateItem);
        }
        
        private bool CheckItemAvailability()
        {
            var isCreationAvailable = false;
            var allItems = new List<BaseEntity>();
            foreach (var repository in _itemRepository)
                allItems = allItems.Union(repository.GetAll()).ToList();

            foreach (var requiredItem in _requiredItems)
            {
                var requiredItemType = requiredItem.GetType();
                isCreationAvailable = allItems.Any(item => item.GetType() == requiredItemType);
                if(!isCreationAvailable)
                    break;
            }

            return isCreationAvailable;
        }

        private void CreateItem()
        {
            foreach (var requiredItem in _requiredItems)
            {
                foreach (var repository in _itemRepository)
                {
                    if (repository.TryGet(requiredItem, out var item))
                        item.Destroy();
                }
            }
            _itemSpawnerView.SpawnItem();
            _isStartProcessCreating = false;
            
            CreateItemIfNeeded();
        }
    }
}