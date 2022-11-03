using UnityEngine;
using UnityEngine.InputSystem;
using ItemsSeeker.Core;
using ItemsSeeker.Levels.Detection;

namespace ItemsSeeker.Levels
{
    public class LevelRoot : CompositionRoot
    {
        [SerializeField] PlayerInput _playerInput;
        [SerializeField] Detector _detector;
        [SerializeField] RequiredItemListSettings _requiredItemListSettings;
        [SerializeField] RequiredItemListView _requiredItemListView;

        RequiredItemList _requiredItemList;
        ItemPickUp _itemPickUp;

        public override void Compose(ScenesManager scenesManager, MonoBehaviour _coroutineHolder)
        {
            var requiredItemList = new RequiredItemList(_requiredItemListSettings);
            var itemPickUp = new ItemPickUp(_detector, _playerInput, requiredItemList);

            _requiredItemList = requiredItemList;
            _itemPickUp = itemPickUp;

            InitView();
        }

        void InitView()
        {
            _requiredItemListView.Init(_requiredItemList);
        }
    }
}
