using System.Collections.Generic;
using UnityEngine;

namespace ItemsSeeker.Core
{
    public abstract class CompositionRoot : MonoBehaviour
    {
        List<SceneComponent> _sceneComponents = new List<SceneComponent>();

        public abstract void Compose(ScenesManager scenesManager, MonoBehaviour coroutineHolder, GameLoop gameLoop);

        public void RegisterSceneComponent(SceneComponent sceneComponent)
        {
            _sceneComponents.Add(sceneComponent);
        }

        public virtual void OnSceneLoaded()
        {
            foreach (var component in _sceneComponents)
                component.OnSceneLoaded();
        }

        public virtual void OnSceneWillUnload()
        {
            foreach (var component in _sceneComponents)
                component.OnSceneWillUnload();

            _sceneComponents.Clear();
        }
    }
}
