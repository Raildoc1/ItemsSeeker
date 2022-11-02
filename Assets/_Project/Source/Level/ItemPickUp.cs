using UnityEngine;
using UnityEngine.InputSystem;
using ItemsSeeker.Levels.Detection;

namespace ItemsSeeker.Levels
{
    class ItemPickUp
    {
        readonly Detector _detector;
        readonly RequiredItemList _requiredItemList;

        public ItemPickUp(
            Detector detector,
            PlayerInput playerInput,
            RequiredItemList requiredItemList
        )
        {
            _detector = detector;
            _requiredItemList = requiredItemList;

            var inputActionMap = playerInput.currentActionMap;
            var main = inputActionMap.FindAction("Main");

            main.performed += OnMainAction;
        }

        void OnMainAction(InputAction.CallbackContext context)
        {
            Debug.Log(_detector.Focus?.GetType());

            if (_detector.Focus is not PickUpItem pickUpItem)
                return;

            if (_requiredItemList.TryRemoveItem(pickUpItem.Name))
                pickUpItem.PickUp();
        }
    }
}
