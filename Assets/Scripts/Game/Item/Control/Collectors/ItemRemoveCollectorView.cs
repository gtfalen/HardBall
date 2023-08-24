namespace Game.Item
{
    public class ItemRemoveCollectorView: BaseItemCollector
    {
        protected override void OnCollectItem(ItemRepository collectedRepository)
        {
            if(collectedRepository.TryGetItem(out var item))
                item.Destroy();
        }
    }
}