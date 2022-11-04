using UnityEngine;

namespace ItemsSeeker.Levels
{
    [System.Serializable]
    [CreateAssetMenu(menuName = "Settings/Detector")]
    class DetectorSettings : ScriptableObject
    {
        [SerializeField]
        private LayerMask _detectLayers;
        public LayerMask DetectLayers => _detectLayers;
    }
}
