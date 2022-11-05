using ItemsSeeker.Core;
using System;
using UnityEngine.InputSystem;

namespace ItemsSeeker.Levels
{
    class InGameMenu : SceneComponent
    {
        readonly ScenesManager _scenesManager;
        readonly InputAction _pause;
        bool _active;

        public event Action OnActivated;
        public event Action OnDeactivated;

        public bool Active => _active;

        public InGameMenu(
            CompositionRoot root,
            ScenesManager scenesManager,
            PlayerInput playerInput
        )
            : base(root)
        {
            _scenesManager = scenesManager;
            _pause = playerInput.currentActionMap.FindAction("Pause");
        }

        public override void OnSceneLoaded()
        {
            _pause.performed += OnPauseAction;
        }

        public override void OnSceneWillUnload()
        {
            _pause.performed -= OnPauseAction;
        }

        void OnPauseAction(InputAction.CallbackContext context)
        {
            _active = !_active;
            if (_active)
                OnActivated?.Invoke();
            else
                OnDeactivated?.Invoke();
        }

        public void QuitLevel()
        {
            _scenesManager.GoToMainMenu();
        }
    }
}
