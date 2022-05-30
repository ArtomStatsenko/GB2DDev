using Game.InputLogic;
using Profile;
using Tools;
<<<<<<< Updated upstream
=======
using UnityEngine;
>>>>>>> Stashed changes

internal class GameController : BaseController
{
    private readonly PlayerData _model;
    private CarController _car;
    private InputController _input;
    private BackgroundController _background;

    public GameController(PlayerData model)
    {
        _model = model;

        var movement = new SubscriptionProperty<float>();

        CarController carController = new CarController();
        AddController(carController);

        InputController inputController = new InputController(movement);
        AddController(inputController);

        BackgroundController backgroundController = new BackgroundController(movement, _model.CurrentCar.Speed);
        AddController(backgroundController);
    }
}
