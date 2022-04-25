using Game;
using Tools;
using UnityEngine;

internal class BackgroundController : BaseController
{
    private readonly ResourcePath _viewPath = new ResourcePath { PathResource = "Prefabs/background" };
    private readonly IReadOnlySubscriptionProperty<float> _movement;
    private BackgroundView _view;

    public BackgroundController(IReadOnlySubscriptionProperty<float> movement, float carSpeed)
    {
        _movement = movement;
        _view = CreateView();
        _view.Init(_movement, carSpeed);
    }

    private BackgroundView CreateView()
    {
        GameObject view = Object.Instantiate(ResourceLoader.LoadPrefab(_viewPath));
        AddGameObject(view);
        return view.GetComponent<BackgroundView>();
    }
}
