using System.Collections.Generic;
using UnityEngine;

namespace ItemsSeeker.Levels
{
    [System.Serializable]
    [CreateAssetMenu]
    class RequiredItemListSettings : ScriptableObject
    {
        [SerializeField]
        private string[] _requiredItems;
        public IReadOnlyList<string> RequiredItems => _requiredItems;
    }
}
