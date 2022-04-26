using Profile;
using System.Linq;
using Tools;
using UnityEngine;

namespace UI
{
    internal class MainMenuController : BaseController
    {
        private readonly PlayerData _profilePlayer;
        private readonly MainMenuView _view;

        public MainMenuController(Transform placeForUi, PlayerData profilePlayer)
        {
            _profilePlayer = profilePlayer;
            _view = ResourceLoader.LoadAndInstantiateObject<MainMenuView>(new ResourcePath { PathResource = "Prefabs/mainMenu" }, placeForUi, false);
            AddGameObject(_view.gameObject);
            _view.Init(StartGame);
            var shedController = ConfigureShedController(placeForUi, profilePlayer);
        }

        private BaseController ConfigureShedController(Transform placeForUi, PlayerData profilePlayer)
        {
            var upgradeItemsConfigCollection
            = ContentDataSourceLoader.LoadUpgradeItemConfigs(new ResourcePath
            {
                PathResource
            = "DataSource/Upgrade/UpgradeItemConfigDataSource"
            });
            var upgradeItemsRepository = new UpgradeHandlersRepository(upgradeItemsConfigCollection);
            var itemsRepository = new ItemsRepository(upgradeItemsConfigCollection.Select(value => value.ItemConfig).ToList());
            var inventoryModel = new InventoryModel();
            var inventoryViewPath = new ResourcePath { PathResource = $"Prefabs/{nameof(InventoryView)}" };
            var inventoryView = ResourceLoader.LoadAndInstantiateObject<InventoryView>(inventoryViewPath, placeForUi, false);
            AddGameObject(inventoryView.gameObject);
            var inventoryController = new InventoryController(inventoryModel,  inventoryView, itemsRepository);
            AddController(inventoryController);
            var shedController = new ShedController(upgradeItemsRepository, inventoryController,
            profilePlayer.CurrentCar);
            AddController(shedController);
            return shedController;
        }

        private void StartGame()
        {
            _profilePlayer.GameState.Value = GameState.Game;
            _profilePlayer.AnalyticTool.SendMessage("start_game");
        }
    }
}