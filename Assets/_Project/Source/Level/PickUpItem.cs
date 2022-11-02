using ItemsSeeker.Levels.Detection;
using UnityEngine;

namespace ItemsSeeker.Levels
{
    class PickUpItem : MonoBehaviour, IDetectable
    {
        [SerializeField] string _name;

        public string Name => _name;

        public void PickUp()
        {
            Destroy(gameObject);
        }
    }
}
