using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace ItemsSeeker.Levels.Detection
{
    public class Detector : MonoBehaviour
    {
        public event Action OnFocusChanged;

        [SerializeField] Camera _camera;
        [SerializeField] PlayerInput _playerInput;
        [SerializeField] LayerMask _layerMask;

        public IDetectable Focus => _focus;

        IDetectable _focus;

        void Update()
        {
            var newFocus = FindFocus();

            if(_focus != newFocus)
            {
                OnFocusChanged?.Invoke();
                _focus = newFocus;
            }
        }

        IDetectable FindFocus()
        {
            var ray = _camera.ScreenPointToRay(Mouse.current.position.ReadValue());

            var hits = Physics.RaycastAll(ray.origin, ray.direction, Mathf.Infinity, _layerMask);

            for (int i = 0; i < hits.Length; i++)
            {
                if (hits[i].collider.gameObject.TryGetComponent<IDetectable>(out var detectable))
                    return detectable;
            }

            return null;
        }
    }
}
