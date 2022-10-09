using System.Collections;
using UnityEngine;

namespace ItemsSeeker.Core
{
    public class Main : MonoBehaviour
    {
        ScenesManager _scenesManager;

        void Awake()
        {
            _scenesManager = new ScenesManager(this);
        }

        IEnumerator Start()
        {
            yield return _scenesManager.GoToMainMenu();
        }
    }
}