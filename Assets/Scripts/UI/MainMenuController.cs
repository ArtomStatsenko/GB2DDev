using Profile;
using Tools;
using UnityEngine;

namespace UI
{
    internal class MainMenuController : BaseController
    {
        private readonly ResourcePath _viewPath = new ResourcePath { PathResource = "Prefabs/mainMenu" };
        private readonly PlayerData _model;
        private MainMenuView _view;

        public MainMenuController(PlayerData model, Transform uiRoot)
        {
            _model = model;
            _view = CreateView(uiRoot);
            _view.Init(StartGame);
        }

        private MainMenuView CreateView(Transform uiRoot)
        {
            GameObject viewObject = Object.Instantiate(ResourceLoader.LoadPrefab(_viewPath), uiRoot, false);
            AddGameObject(viewObject);
            return viewObject.GetComponent<MainMenuView>();
        }

        private void StartGame()
        {
            _model.GameState.Value = GameState.Game;
        }
    }
}