using ItemsSeeker.Levels.Detection;
using UnityEngine;
using UnityEngine.InputSystem;

namespace ItemsSeeker.Levels
{
    public class ItemPickUp
    {
        readonly Detector _detector;

        public ItemPickUp(Detector detector, PlayerInput playerInput)
        {
            _detector = detector;

            var inputActionMap = playerInput.currentActionMap;
            var main = inputActionMap.FindAction("Main");

            main.performed += OnMainAction;
        }

        void OnMainAction(InputAction.CallbackContext context)
        {
            Debug.Log($"Main -> {_detector.Focus}");
        }
    }
}
