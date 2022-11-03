using TMPro;
using UnityEngine;

namespace ItemsSeeker.Levels.View
{
    public class ItemNameView : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI _textMesh;

        public void Init(string itemName)
        {
            _textMesh.text = itemName;
        }

        public void Strikethrough()
        {
            _textMesh.fontStyle = FontStyles.Strikethrough;
        }
    }
}
