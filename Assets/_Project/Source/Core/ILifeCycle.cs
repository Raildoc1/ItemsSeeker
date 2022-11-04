using System;

namespace ItemsSeeker.Core
{
    public interface ILifeCycle
    {
        event Action OnSceneStartUnloading;
    }
}
