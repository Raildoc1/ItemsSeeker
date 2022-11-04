using ItemsSeeker.Core;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

namespace ItemsSeeker
{
    public class MainMenuRoot : CompositionRoot
    {
        [SerializeField] List<Button> _levelButtons;
        [SerializeField] Button _quitButton;

        public override void Compose(ScenesManager scenesManager, MonoBehaviour _coroutineHolder, GameLoop gameLoop)
        {
            for (int i = 0; i < _levelButtons.Count; i++)
            {
                int levelNumber = i + 1;
                _levelButtons[i].onClick.AddListener(() => _coroutineHolder.StartCoroutine(scenesManager.GoToLevel(levelNumber)));
            }

            _quitButton.onClick.AddListener(() =>
            {
#if UNITY_EDITOR
                EditorApplication.ExitPlaymode();
#else
                Application.Quit();
#endif
            }
            );
        }
    }
}
