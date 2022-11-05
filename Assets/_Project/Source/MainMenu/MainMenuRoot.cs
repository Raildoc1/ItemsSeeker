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
        [SerializeField] FadeScreen _fadeScreen;

        MonoBehaviour _coroutineHolder;
        ScenesManager _scenesManager;

        public override void Compose(ScenesManager scenesManager, MonoBehaviour coroutineHolder, GameLoop gameLoop)
        {
            _coroutineHolder = coroutineHolder;
            _scenesManager = scenesManager;

            _fadeScreen.FadeIn(Construct);
        }

        void Construct()
        {
            for (int i = 0; i < _levelButtons.Count; i++)
            {
                int levelNumber = i + 1;
                _levelButtons[i].onClick.AddListener(() =>
                _fadeScreen.FadeOut(() =>
                        _coroutineHolder.StartCoroutine(_scenesManager.GoToLevel(levelNumber))
                    )
                );
            }

            _quitButton.onClick.AddListener(() =>
            {
#if UNITY_EDITOR
                _fadeScreen.FadeOut(() => EditorApplication.ExitPlaymode());
#else
                _fadeScreen.FadeOut(() => Application.Quit());
#endif
            }
            );
        }
    }
}
