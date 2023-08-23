namespace Game.Item
{
    public class ItemRemoveCollectorView: BaseItemCollector
    {
        protected override void OnCollectItem(ItemDistributorView itemDistributorView)
        {
            if(itemDistributorView.ItemRepositoryView.TryGet(out var item))
                item.Destroy();
        }
    }
}