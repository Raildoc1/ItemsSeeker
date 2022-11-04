using UnityEngine;

namespace ItemsSeeker.Core
{
    public abstract class CompositionRoot : MonoBehaviour
    {
        public abstract void Compose(ScenesManager scenesManager, MonoBehaviour coroutineHolder, GameLoop gameLoop);
    }
}
