using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

internal abstract class BaseController : IDisposable
{
    private List<BaseController> _baseControllers = new List<BaseController>();
    private List<GameObject> _gameObjects = new List<GameObject>();
    private bool _isDisposed;

    public void Dispose()
    {
        if (_isDisposed)
        {
            return;
        }

        OnDispose();

        foreach (BaseController controller in _baseControllers)
        {
            controller?.Dispose();
        }
        _baseControllers.Clear();

        foreach (GameObject cachedGameObject in _gameObjects)
        {
            if (cachedGameObject != null)
            {
                Object.Destroy(cachedGameObject);
            }
        }
        _gameObjects.Clear();
    }

    protected virtual void OnDispose()
    {

    }

    protected void AddController(BaseController controller)
    {
        if (_baseControllers == null)
        {
            _baseControllers = new List<BaseController>();
        }
        _baseControllers.Add(controller);
    }

    protected void AddGameObject (GameObject gameObject)
    {
        if (_gameObjects == null)
        {
            _gameObjects = new List<GameObject>();
        }
        _gameObjects.Add(gameObject);
    }
}