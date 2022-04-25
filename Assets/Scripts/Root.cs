using Profile;
using UnityEngine;

internal class Root : MonoBehaviour
{
    [SerializeField]
    private Transform _uiRoot;

    private float _carSpeed = 0.1f;

    private MainController _controller;

    private void Start()
    {
        PlayerData model = new PlayerData(_carSpeed);
        model.GameState.Value = GameState.Game;

        _controller = new MainController(model, _uiRoot);
    }

    private void OnDestroy()
    {
        _controller.Dispose();
    }
}
