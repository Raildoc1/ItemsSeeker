using ItemsSeeker.Core;
using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace ItemsSeeker.Levels
{
    class Detector
    {
        Camera _camera;
        DetectorSettings _settings;
        ILifeCycle _lifeCycle;
        GameLoop _gameLoop;

        public Detector(GameLoop gameLoop, ILifeCycle lifeCycle, Camera camera, DetectorSettings settings)
        {
            _camera = camera;
            _settings = settings;
            _lifeCycle = lifeCycle;
            _gameLoop = gameLoop;

            gameLoop.onTick += Tick;
            lifeCycle.OnSceneStartUnloading += OnSceneStartUnloading;
        }

        void OnSceneStartUnloading()
        {
            _gameLoop.onTick -= Tick;
            _lifeCycle.OnSceneStartUnloading -= OnSceneStartUnloading;
        }

        IDetectable _focus;

        public event Action OnFocusChanged;

        public IDetectable Focus => _focus;

        void Tick()
        {
            var newFocus = FindFocus();

            if (_focus != newFocus)
            {
                OnFocusChanged?.Invoke();
                _focus = newFocus;
            }
        }

        IDetectable FindFocus()
        {
            var ray = _camera.ScreenPointToRay(Mouse.current.position.ReadValue());
            var hits = Physics.RaycastAll(ray.origin, ray.direction, Mathf.Infinity, _settings.DetectLayers);

            for (int i = 0; i < hits.Length; i++)
            {
                if (hits[i].collider.gameObject.TryGetComponent<IDetectable>(out var detectable))
                    return detectable;
            }

            return null;
        }
    }
}
