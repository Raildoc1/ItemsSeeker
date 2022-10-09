using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ItemsSeeker.Core
{
    public class ScenesManager
    {
        const string MenuSceneName = "MainMenu";
        const string LevelSceneNameFormat = "Level_{0}";

        readonly MonoBehaviour _coroutineHolder;

        public ScenesManager(MonoBehaviour coroutineHolder)
        {
            _coroutineHolder = coroutineHolder;
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
            while (SceneManager.sceneCount > 1)
            {
                var currentSceneName = SceneManager.GetSceneAt(1).name;
                Debug.Log($"Unloading {currentSceneName}...");
                yield return SceneManager.UnloadSceneAsync(currentSceneName);
                Debug.Log($"Unloaded");
            }

            Debug.Log($"Loading scene {sceneName}...");
            yield return SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
            Debug.Log($"Scene {sceneName} loaded successfully!");

            var compositionRoots = Object.FindObjectsOfType<CompositionRoot>();

            if (compositionRoots.Length > 1)
                Debug.LogError("More than one composition root found!");

            if (compositionRoots.Length == 0)
                Debug.LogError("No composition root found!");

            compositionRoots[0].Compose(this, _coroutineHolder);
        }
    }
}
