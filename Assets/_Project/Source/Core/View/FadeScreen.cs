using DG.Tweening;
using System;
using UnityEngine;

namespace ItemsSeeker.Core
{
    [RequireComponent(typeof(CanvasGroup))]
    public class FadeScreen : ViewMono
    {
        [SerializeField] float _fadeDuration = 0.5f;

        CanvasGroup _canvasGroup;
        Tween _currentTween;

        void Awake()
        {
            _canvasGroup = GetComponent<CanvasGroup>();
        }

        public void Construct(CompositionRoot root)
        {
            root.RegisterView(this);
        }

        public override void Init()
        {
            FadeIn();
        }

        public override void Deinit()
        {
        }

        public void FadeIn(Action onFadeIn = null)
        {
            gameObject.SetActive(true);
            _currentTween?.Kill();
            _currentTween = _canvasGroup.DOFade(0f, _fadeDuration)
                                        .OnComplete(() =>
                                        {
                                            gameObject.SetActive(false);
                                            onFadeIn?.Invoke();
                                        });
        }

        public void FadeOut(Action onFadeOut = null)
        {
            gameObject.SetActive(true);
            _currentTween?.Kill();
            _currentTween = _canvasGroup.DOFade(1f, _fadeDuration)
                                        .OnComplete(() =>
                                        {
                                            onFadeOut?.Invoke();
                                        });
        }
    }
}
