using Profile;
using Tools;
using UnityEngine;

namespace UI
{
    internal class MainMenuController : BaseController
    {
        private readonly ResourcePath _viewPath = new ResourcePath { PathResource = "Prefabs/mainMenu" };
        private readonly ResourcePath _trailViewPath = new ResourcePath { PathResource = "Prefabs/trailTouch" };
        private readonly PlayerData _model;
        private readonly MainMenuView _view;
        private readonly TrailTouchView _trailView;

        public MainMenuController(PlayerData model, Transform uiRoot)
        {
            _model = model;
            _view = CreateView(uiRoot);
            _view.Init(StartGame);
            _trailView = CreateTrailView(uiRoot);
            _trailView.Init();
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
            _model.AnalyticTool.SendMessage("start_game");
        }

        private TrailTouchView CreateTrailView(Transform uiRoot)
        {
            GameObject viewObject = Object.Instantiate(ResourceLoader.LoadPrefab(_trailViewPath), uiRoot, false);
            AddGameObject(viewObject);
            return viewObject.GetComponent<TrailTouchView>();
        }

    }
}