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
            _inGameMenu.OnActivated += Open;
            _inGameMenu.OnDeactivated += Close;
        }

        void OnDestroy()
        {
            _inGameMenu.OnDeactivated -= Close;
            _inGameMenu.OnActivated -= Open;
            _quitButton.onClick.RemoveListener(Quit);
        }

        void Open()
        {
            gameObject.SetActive(true);
        }

        void Close()
        {
            gameObject.SetActive(false);
        }

        void Quit()
        {
            _inGameMenu.QuitLevel();
        }
    }
}
