using ItemsSeeker.Core;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ItemsSeeker
{
    public class MainMenuRoot : CompositionRoot
    {
        [SerializeField] private List<Button> _levelButtons;

        public override void Compose(ScenesManager scenesManager, MonoBehaviour _coroutineHolder)
        {
            for (int i = 0; i < _levelButtons.Count; i++)
            {
                int levelNumber = i + 1;
                _levelButtons[i].onClick.AddListener(() => _coroutineHolder.StartCoroutine(scenesManager.GoToLevel(levelNumber)));
            }
        }
    }
}
