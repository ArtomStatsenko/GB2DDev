using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

internal abstract class BaseController : IDisposable
{
    private List<BaseController> _baseControllers;
    private List<GameObject> _gameObjects;
    private bool _isDisposed;

    public void Dispose()
    {
        if (_isDisposed)
        {
            return;
        }

        OnDispose();

        if (_baseControllers != null)
        {
            foreach (BaseController controller in _baseControllers)
            {
                controller?.Dispose();
            }
            _baseControllers.Clear();
        }

        if (_gameObjects != null)
        {
            foreach (GameObject cachedGameObject in _gameObjects)
            {
                Object.Destroy(cachedGameObject);
            }
            _gameObjects.Clear();
        }
    }

    protected virtual void OnDispose()
    {
        //TODO smth
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