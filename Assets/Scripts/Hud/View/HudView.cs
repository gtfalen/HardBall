using Game.Economy;
using TMPro;
using UI;
using UniRx;
using UnityEngine;
using Zenject;

namespace MainMenu.View
{
    public class HudView: BaseView<HudView.Model>
    {
        [SerializeField] private TextMeshProUGUI _moneyText;

        private CompositeDisposable _compositeDisposable;
        
        public override void OnShow(Model model)
        {
            _compositeDisposable = new();
            model.CurrentMoney
                .Subscribe(money => _moneyText.text = money + "$")
                .AddTo(_compositeDisposable);
        }

        public override void OnHide() => _compositeDisposable.Dispose();

        public class Model
        {
            public ReactiveProperty<int> CurrentMoney { get; }

            public Model(ReactiveProperty<int> currentMoney)
            {
                CurrentMoney = currentMoney;
            }
        }
    }

    public class HudViewPresenter: IHudViewPresenter, IInitializable
    {
        private readonly IUIPrefabs _uiPrefabs;
        private readonly IUIControlService _uiControlService;
        private readonly IMoneyService _moneyService;

        private HudView _hudView;
        private HudView.Model _model;
        
        public HudViewPresenter
        (
            IUIPrefabs uiPrefabs,
            IUIControlService uiControlService,
            IMoneyService moneyService
        )
        {
            _uiPrefabs = uiPrefabs;
            _uiControlService = uiControlService;
            _moneyService = moneyService;
        }

        public void Initialize()
        {
            _model = new HudView.Model(_moneyService.Money);
            _hudView = _uiControlService.Create(_uiPrefabs.HudView, _model);
            _hudView.Hide();
        }

        public void Show() => _hudView.Show();

        public void Hide() => _hudView.Hide();
    }

    public interface IHudViewPresenter
    {
        void Show();
        void Hide();
    }
}