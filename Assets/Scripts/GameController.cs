using Game.InputLogic;
using Profile;
using Tools;
using UnityEngine;

internal class GameController : BaseController
{
    private readonly PlayerData _model;
    private CarController _car;
    private InputController _input;
    private BackgroundController _background;

    public GameController(Transform placeForUi, PlayerData model)
    {
        _model = model;

        var movement = new SubscriptionProperty<float>();

        CarController carController = new CarController();
        AddController(carController);

        InputController inputController = new InputController(movement);
        AddController(inputController);

        BackgroundController backgroundController = new BackgroundController(movement, _model.CurrentCar.Speed);
        AddController(backgroundController);
        var abilityController = ConfigureAbilityController(placeForUi, carController);
    }

    private IAbilitiesController ConfigureAbilityController(Transform placeForUi, IAbilityActivator abilityActivator)
    {
        var abilityItemsConfigCollection = ContentDataSourceLoader.LoadAbilityItemConfigs(new ResourcePath
        {
            PathResource = "DataSource/Ability/AbilityItemConfigDataSource"
        });
        var abilityRepository = new AbilityRepository(abilityItemsConfigCollection);
        var abilityCollectionViewPath = new ResourcePath { PathResource = $"Prefabs/{nameof(AbilityCollectionView)}" };
        var abilityCollectionView = ResourceLoader.LoadAndInstantiateObject<AbilityCollectionView>(abilityCollectionViewPath, placeForUi, false);
        AddGameObject(abilityCollectionView.gameObject);
        var inventoryModel = new InventoryModel();
        var abilitiesController = new AbilitiesController(abilityRepository, inventoryModel, abilityCollectionView, abilityActivator);
        AddController(abilitiesController);
        return abilitiesController;
    }
}
