using Profile;
using Tools;
using UnityEngine;

namespace UI
{
    internal class MainMenuController : BaseController
    {
        private readonly ResourcePath _viewPath = new ResourcePath { PathResource = "Prefabs/mainMenu" };
        private readonly ProfilePlayer _profilePlayer;
        private MainMenuView _view;

        public MainMenuController(Transform placeForUI, ProfilePlayer profilePlayer)
        {
            _profilePlayer = profilePlayer;
            _view = LoadView(placeForUI);
            _view.Init(StartGame);
        }

        private MainMenuView LoadView(Transform placeForUI)
        {
            GameObject viewObject = Object.Instantiate(ResourceLoader.LoadPrefab(_viewPath), placeForUI, false);
            AddGameObject(viewObject);
            return viewObject.GetComponent<MainMenuView>();
        }

        private void StartGame()
        {
            _profilePlayer.CurrentState.Value = GameState.Game;
        }
    }
}