using UnityEngine;

namespace Game.Item
{
    public class ItemPlayerCollectorView: BaseItemCollector
    {
        [Header("Player repository")] 
        [SerializeField] private ItemRepositoryView _itemRepositoryView;
        
        protected override void OnCollectItem(ItemDistributorView itemDistributorView)
        {
            if(!_itemRepositoryView.IsFreeSpace())
                return;

            if (itemDistributorView.TryGetItem(out var receivedItem))
                _itemRepositoryView.TryAdd(receivedItem);
        }
    }
}