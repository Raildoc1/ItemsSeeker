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

        public override void Compose(ScenesManager scenesManager, MonoBehaviour _coroutineHolder)
        {
            var requiredItemList = new RequiredItemList(_requiredItemListSettings);
            var itemPickUp = new ItemPickUp(_detector, _playerInput, requiredItemList);
        }
    }
}
