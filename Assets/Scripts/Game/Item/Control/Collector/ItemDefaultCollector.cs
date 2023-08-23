using UnityEngine;

namespace Game.Item
{
    public class ItemDefaultCollector: BaseItemCollector
    {
        [Header("Item repository")] 
        [SerializeField] private ItemRepositoryView _itemRepositoryView;
        
        [Header("Collected Item")] 
        [SerializeField] private ItemView _collectedItem;
        
        protected override void OnCollectItem(ItemDistributorView itemDistributorView)
        {
            if (itemDistributorView.ItemRepositoryView.TryGet(_collectedItem, out var receivedItem))
                _itemRepositoryView.TryAdd(receivedItem);
        }
    }
}