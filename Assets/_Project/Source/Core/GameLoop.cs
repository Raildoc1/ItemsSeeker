using System;
using UnityEngine;

namespace ItemsSeeker.Core
{
    public class GameLoop : MonoBehaviour
    {
        public event Action onTick;

        void Update()
        {
            onTick?.Invoke();
        }
    }
}
