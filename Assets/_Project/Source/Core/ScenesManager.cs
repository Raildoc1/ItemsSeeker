using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using Object = UnityEngine.Object;

namespace ItemsSeeker.Core
{
    public class ScenesManager : ILifeCycle
    {
        const string MenuSceneName = "MainMenu";
        const string LevelSceneNameFormat = "Level_{0}";

        readonly MonoBehaviour _coroutineHolder;
        readonly GameLoop _gameLoop;

        public event Action OnSceneStartUnloading;

        public ScenesManager(MonoBehaviour coroutineHolder, GameLoop gameLoop)
        {
            _coroutineHolder = coroutineHolder;
            _gameLoop = gameLoop;
        }

        public IEnumerator GoToLevel(int number)
        {
            string sceneName = string.Format(LevelSceneNameFormat, number);
            yield return LoadSceneAsync(sceneName);
        }

        public IEnumerator GoToMainMenu()
        {
            yield return LoadSceneAsync(MenuSceneName);
        }

        IEnumerator LoadSceneAsync(string sceneName)
        {
            OnSceneStartUnloading?.Invoke();

            while (SceneManager.sceneCount > 1)
            {
                var currentSceneName = SceneManager.GetSceneAt(1).name;
                yield return SceneManager.UnloadSceneAsync(currentSceneName);
            }

            yield return SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);

            var compositionRoots = Object.FindObjectsOfType<CompositionRoot>();

            if (compositionRoots.Length > 1)
                Debug.LogError("More than one composition root found!");

            if (compositionRoots.Length == 0)
                Debug.LogError("No composition root found!");

            compositionRoots[0].Compose(this, _coroutineHolder, _gameLoop);
        }
    }
}
