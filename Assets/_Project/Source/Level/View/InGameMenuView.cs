using ItemsSeeker.Core;
using UnityEngine;
using UnityEngine.UI;

namespace ItemsSeeker.Levels.View
{
    class InGameMenuView : ViewMono
    {
        [SerializeField] Button _quitButton;

        InGameMenu _inGameMenu;

        public void Construct(CompositionRoot root, InGameMenu inGameMenu)
        {
            root.RegisterView(this);

            _inGameMenu = inGameMenu;
        }

        public override void Init()
        {
            _quitButton.onClick.AddListener(Quit);
            _inGameMenu.OnActivated += Open;
            _inGameMenu.OnDeactivated += Close;
        }

        public override void Deinit()
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
