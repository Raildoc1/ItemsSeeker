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

        RequiredItemList _requiredItemList;
        ItemPicker _itemPicker;
        InGameMenu _inGameMenu;
        Detector _detector;

        public override void Compose(ScenesManager scenesManager, MonoBehaviour coroutineHolder, GameLoop gameLoop)
        {
            var detector = new Detector(gameLoop, scenesManager, _camera, _detectorSettings);
            var requiredItemList = new RequiredItemList(_requiredItemListSettings);
            var itemPicker = new ItemPicker(detector, _playerInput, requiredItemList);
            var inGameMenu = new InGameMenu(scenesManager, coroutineHolder);

            _requiredItemList = requiredItemList;
            _itemPicker = itemPicker;
            _inGameMenu = inGameMenu;

            InitView();
        }

        void InitView()
        {
            _requiredItemListView.Init(_requiredItemList);
            _inGameMenuView.Init(_inGameMenu);
        }
    }
}
