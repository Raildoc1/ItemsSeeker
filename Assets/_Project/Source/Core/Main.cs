using System.Collections;
using UnityEngine;

namespace ItemsSeeker.Core
{
    public class Main : MonoBehaviour
    {
        [SerializeField] GameLoop _gameLoop;

        ScenesManager _scenesManager;

        void Awake()
        {
            _scenesManager = new ScenesManager(this, _gameLoop);
        }

        IEnumerator Start()
        {
            yield return _scenesManager.GoToMainMenu();
        }
    }
}