using ItemsSeeker.Core;
using UnityEngine.InputSystem;

namespace ItemsSeeker.Levels
{
    class ItemPicker : SceneComponent
    {
        readonly Detector _detector;
        readonly RequiredItemList _requiredItemList;
        readonly InputAction _main;

        public ItemPicker(
            CompositionRoot root,
            Detector detector,
            PlayerInput playerInput,
            RequiredItemList requiredItemList
        )
            : base(root)
        {
            _detector = detector;
            _requiredItemList = requiredItemList;

            _main = playerInput.currentActionMap.FindAction("Main");
        }

        public override void OnSceneLoaded()
        {
            _main.performed += OnMainAction;
        }

        public override void OnSceneWillUnload()
        {
            _main.performed -= OnMainAction;
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
