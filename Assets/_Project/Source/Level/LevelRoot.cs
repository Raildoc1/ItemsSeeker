using UnityEngine;
using UnityEngine.InputSystem;
using ItemsSeeker.Core;
using ItemsSeeker.Levels.View;

namespace ItemsSeeker.Levels
{
    public class LevelRoot : CompositionRoot
    {
        [Header("Common")]
        [SerializeField] PlayerInput _playerInput;
        [SerializeField] Camera _camera;

        [Header("Settings")]
        [SerializeField] RequiredItemListSettings _requiredItemListSettings;
        [SerializeField] DetectorSettings _detectorSettings;

        [Header("View")]
        [SerializeField] RequiredItemListView _requiredItemListView;
        [SerializeField] InGameMenuView _inGameMenuView;

        public override void Compose(ScenesManager scenesManager, MonoBehaviour coroutineHolder, GameLoop gameLoop)
        {
            var detector = new Detector(this, gameLoop, _camera, _detectorSettings);
            var requiredItemList = new RequiredItemList(this, _requiredItemListSettings);
            var itemPicker = new ItemPicker(this, detector, _playerInput, requiredItemList);
            var inGameMenu = new InGameMenu(this, scenesManager, _playerInput);

            _requiredItemListView.Construct(this, requiredItemList);
            _inGameMenuView.Construct(this, inGameMenu);
        }
    }
}
