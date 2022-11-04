using ItemsSeeker.Core;
using UnityEngine;

namespace ItemsSeeker.Levels
{
    class InGameMenu
    {
        ScenesManager _scenesManager;
        MonoBehaviour _coroutineHolder;

        public InGameMenu(ScenesManager scenesManager, MonoBehaviour coroutineHolder)        {
            _scenesManager = scenesManager;
            _coroutineHolder = coroutineHolder;
        }

        public void QuitLevel()
        {
            _coroutineHolder.StartCoroutine(_scenesManager.GoToMainMenu());
        }
    }
}
