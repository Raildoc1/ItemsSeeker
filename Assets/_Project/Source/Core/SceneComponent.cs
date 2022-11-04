namespace ItemsSeeker.Core
{
    public abstract class SceneComponent
    {
        public SceneComponent(CompositionRoot root)
        {
            root.RegisterSceneComponent(this);
        }

        public abstract void OnSceneLoaded();
        public abstract void OnSceneWillUnload();
    }
}
