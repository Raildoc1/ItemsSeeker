using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace ItemsSeeker.Levels
{
    public class Detector : MonoBehaviour
    {
        [SerializeField] Camera _camera;
        [SerializeField] PlayerInput _playerInput;
        [SerializeField] LayerMask _layerMask;

        IDetectable _focus;

        public event Action OnFocusChanged;

        public IDetectable Focus => _focus;

        void Update()
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
