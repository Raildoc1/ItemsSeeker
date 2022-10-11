using UnityEngine;

namespace ItemsSeeker.Levels.Detection
{
    public class Raycaster
    {
        readonly Transform _origin;
        readonly LayerMask _layerMask;

        public Raycaster(Transform origin, LayerMask layerMask)
        {
            _origin = origin;
            _layerMask = layerMask;
        }
    }
}
