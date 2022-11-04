using ItemsSeeker.Core;
using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace ItemsSeeker.Levels
{
    class Detector : SceneComponent
    {
        Camera _camera;
        DetectorSettings _settings;
        GameLoop _gameLoop;
        IDetectable _focus;

        public event Action OnFocusChanged;

        public IDetectable Focus => _focus;

        public Detector(
            CompositionRoot root,
            GameLoop gameLoop,
            Camera camera,
            DetectorSettings settings
        )
            : base(root)
        {
            _camera = camera;
            _settings = settings;
            _gameLoop = gameLoop;
        }

        public override void OnSceneLoaded()
        {
            _gameLoop.onTick += Tick;
        }

        public override void OnSceneWillUnload()
        {
            _gameLoop.onTick -= Tick;
        }

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
