using UnityEngine;
using UnityEngine.InputSystem;

namespace ItemsSeeker.Levels
{
    class ItemPicker
    {
        readonly Detector _detector;
        readonly RequiredItemList _requiredItemList;

        public ItemPicker(
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
            if (_detector.Focus is not PickUpItem pickUpItem)
                return;

            if (_requiredItemList.TryRemoveItem(pickUpItem.Name))
                pickUpItem.PickUp();
        }
    }
}
