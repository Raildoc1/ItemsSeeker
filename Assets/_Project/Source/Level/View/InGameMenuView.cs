using ItemsSeeker.Core;
using UnityEngine;
using UnityEngine.UI;

namespace ItemsSeeker.Levels.View
{
    class InGameMenuView : ViewMono
    {
        [SerializeField] Button _quitButton;

        InGameMenu _inGameMenu;
        FadeScreen _fadeScreen;

        public void Construct(
            CompositionRoot root,
            InGameMenu inGameMenu,
            FadeScreen fadeScreen
            )
        {
            root.RegisterView(this);

            _inGameMenu = inGameMenu;
            _fadeScreen = fadeScreen;
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
            _fadeScreen.FadeOut(() => _inGameMenu.QuitLevel());
        }
    }
}
