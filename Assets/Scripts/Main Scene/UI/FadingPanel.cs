
using DG.Tweening;
using UnityEngine;

public class FadingPanel : MonoBehaviour
{
    [SerializeField] private CanvasGroup canvasGroup;
    private Tween _fadeTween;

    public void FadeIn(float duration)
    {
        Fade(1f,duration, () =>
        {
            canvasGroup.interactable = true;
            canvasGroup.blocksRaycasts = true;
        });
    }

    public void FadeOut(float duration)
    {
        Fade(0f,duration,() =>
        {
            canvasGroup.interactable = false;
            canvasGroup.blocksRaycasts = false;
        });
    }
    private void Fade(float endValue, float duration,TweenCallback onEnd)
    {
        _fadeTween?.Kill(false);

        _fadeTween = canvasGroup.DOFade(endValue, duration);
        _fadeTween.onComplete += onEnd;
    }

}
