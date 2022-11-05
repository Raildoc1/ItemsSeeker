using System.Collections.Generic;
using UnityEngine;

namespace ItemsSeeker.Core
{
    public abstract class CompositionRoot : MonoBehaviour
    {
        List<SceneComponent> _sceneComponents = new List<SceneComponent>();
        List<ViewMono> _views = new List<ViewMono>();

        public abstract void Compose(ScenesManager scenesManager, MonoBehaviour coroutineHolder, GameLoop gameLoop);

        public void RegisterSceneComponent(SceneComponent sceneComponent)
        {
            _sceneComponents.Add(sceneComponent);
        }

        public void RegisterView(ViewMono viewMono)
        {
            _views.Add(viewMono);
        }

        public virtual void OnSceneLoaded()
        {
            foreach (var component in _sceneComponents)
                component.OnSceneLoaded();

            foreach (var view in _views)
                view.Init();
        }

        public virtual void OnSceneWillUnload()
        {
            foreach (var view in _views)
                view.Deinit();

            _views.Clear();

            foreach (var component in _sceneComponents)
                component.OnSceneWillUnload();

            _sceneComponents.Clear();
        }
    }
}
