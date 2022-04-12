using JoostenProductions;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

internal class TrailTouchView : MonoBehaviour
{
    [SerializeField]
    private TrailRenderer _prefab;

    private Dictionary<int, TrailRenderer> _renderers = new Dictionary<int, TrailRenderer>();
    private List<TrailRenderer> _pool = new List<TrailRenderer>();

    public void Init()
    {
        UpdateManager.SubscribeToUpdate(OnUpdate);
    }

    private void OnUpdate()
    {
        foreach (var touch in Input.touches)
        {
            ProcessTouch(touch);
        }
    }

    private void ProcessTouch(Touch touch)
    {
        switch (touch.phase)
        {
            case TouchPhase.Began:
                StartTouch(touch);
                break;
            case TouchPhase.Moved:
            case TouchPhase.Stationary:
                TouchInProgress(touch);
                break;
            case TouchPhase.Ended:
            case TouchPhase.Canceled:
                ClearTouch(touch);
                break;
        }
    }

    private void StartTouch(Touch touch)
    {
        var existingTrail = _pool.FirstOrDefault(r => !_renderers.Values.Contains(r));
        
        if (existingTrail == null)
        {
            existingTrail = Instantiate(_prefab, transform);
            existingTrail.gameObject.SetActive(false);
            _pool.Add(existingTrail);
        }

        _renderers[touch.fingerId] = existingTrail;
        existingTrail.transform.position = GetTouchWorldPosition(touch);
        existingTrail.emitting = true;
        existingTrail.gameObject.SetActive(true);
    }

    private void TouchInProgress(Touch touch)
    {
        _renderers[touch.fingerId].transform.position = GetTouchWorldPosition(touch);
    }
       
    private void ClearTouch(Touch touch)
    {
        if (_renderers.TryGetValue(touch.fingerId, out var render))
        {
            render.Clear();
            render.gameObject.SetActive(false);
            render.emitting = false;
            _renderers.Remove(touch.fingerId);
        }
    }

    private Vector3 GetTouchWorldPosition(Touch touch)
    {
        Vector3 position = Camera.main.ScreenToWorldPoint(touch.position);
        position.z = transform.position.z;
        return position;
    }

    private void OnDestroy()
    {
        foreach (var render in _pool)
        {
            Destroy(render.gameObject);
        }

        _pool.Clear();
        _renderers.Clear();

        UpdateManager.UnsubscribeFromUpdate(OnUpdate);
    }
}
