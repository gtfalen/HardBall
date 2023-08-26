using TMPro;
using UI;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Item
{
    public class ItemIndicatorView: BaseView<ItemIndicatorView.Model>
    {
        [SerializeField] private Image _itemIco;
        [SerializeField] private TextMeshProUGUI _lable;

        private CompositeDisposable _compositeDisposable;
        
        public override void OnShow(Model model)
        {
            _compositeDisposable = new();
            _itemIco.sprite = model.CollectibleItem.ItemIco;
            model.Count.Subscribe(_ => UpdateIndicator()).AddTo(_compositeDisposable);
            model.MaxCount.Subscribe(_ => UpdateIndicator()).AddTo(_compositeDisposable);
        }

        public override void OnHide() => _compositeDisposable.Dispose();

        private void UpdateIndicator() => _lable.text = CurrentModel.Count + "/" + CurrentModel.MaxCount;

        public class Model
        {
            public IReactiveProperty<int> MaxCount { get; }
            public IReactiveProperty<int> Count { get; }
            public ItemView CollectibleItem { get; }

            public Model(IReactiveProperty<int> maxCount, IReactiveProperty<int> count, ItemView collectibleItem)
            {
                MaxCount = maxCount;
                Count = count;
                CollectibleItem = collectibleItem;
            }
        }
    }
}