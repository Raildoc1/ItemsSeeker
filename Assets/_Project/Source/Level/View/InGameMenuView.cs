using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace ItemsSeeker.Levels.View
{
    class InGameMenuView : MonoBehaviour
    {
        [SerializeField] Button _quitButton;

        InGameMenu _inGameMenu;

        public void Init(InGameMenu inGameMenu)
        {
            _inGameMenu = inGameMenu;

            _quitButton.onClick.AddListener(Quit);
        }

        void Quit()
        {
            _inGameMenu.QuitLevel();
        }
    }
}
