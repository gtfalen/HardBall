using System;
using UI;
using UnityEngine;
using Zenject;

namespace MainMenu.View
{
    public class MainMenuView: BaseView<MainMenuView.Model>
    {
        public void StartNewGame() => CurrentModel.OnStartNewGame?.Invoke();
        public void ExitGame() => Application.Quit();
        
        public class Model
        {
            public Action OnStartNewGame;

            public Model(Action onStartNewGame)
            {
                OnStartNewGame = onStartNewGame;
            }
        }
    }

    public class MainMenuViewPresenter: IMainMenuViewPresenter, IInitializable
    {
        private readonly IUIPrefabs _uiPrefabs;
        private readonly IUIControlService _uiControlService;

        private MainMenuView _mainMenuView;
        private MainMenuView.Model _model;
        
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
            _model = new MainMenuView.Model(StartNewGame);
            _mainMenuView = _uiControlService.Create(_uiPrefabs.MainMenuView, _model);
            _mainMenuView.Hide();
        }

        public void Show() => _mainMenuView.Show();

        public void Hide() => _mainMenuView.Hide();

        private void StartNewGame()
        {
            Hide();
        }
    }

    public interface IMainMenuViewPresenter
    {
        void Show();
        void Hide();
    }
}