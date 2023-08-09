using UI;
using Zenject;

namespace MainMenu.View
{
    public class MainMenuView: BaseView<MainMenuView.Model>
    {

        public class Model
        {
            
        }
    }

    public class MainMenuViewPresenter: IMainMenuViewPresenter, IInitializable
    {
        private readonly IUIPrefabs _uiPrefabs;
        private readonly IUIControlService _uiControlService;

        private MainMenuView _mainMenuView;
        
        public MainMenuViewPresenter
        (
            IUIPrefabs uiPrefabs,
            IUIControlService uiControlService
        )
        {
            _uiPrefabs = uiPrefabs;
            _uiControlService = uiControlService;
        }

        public void Initialize()
        {
            _mainMenuView = _uiControlService.Create(_uiPrefabs.MainMenuView, new MainMenuView.Model());
        }

        public void Show() => _mainMenuView.Show();

        public void Hide() => _mainMenuView.Hide();
    }

    public interface IMainMenuViewPresenter
    {
        void Show();
        void Hide();
    }
}