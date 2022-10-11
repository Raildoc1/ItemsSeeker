using ItemsSeeker.Core;
using ItemsSeeker.Levels.Detection;
using UnityEngine;
using UnityEngine.InputSystem;

namespace ItemsSeeker.Levels
{
    public class LevelRoot : CompositionRoot
    {
        [SerializeField] PlayerInput _playerInput;
        [SerializeField] Detector _detector;
        [Header("Detection")]
        [SerializeField] Camera _camera;
        [SerializeField] LayerMask _layerMask;

        public override void Compose(ScenesManager scenesManager, MonoBehaviour _coroutineHolder)
        {
            var itemPickUp = new ItemPickUp(_detector, _playerInput);
        }
    }
}
