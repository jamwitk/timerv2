
using System;
using DG.Tweening;
using Game;
using UnityEngine;

public class FadingPanel : MonoBehaviour
{
    [SerializeField] private CanvasGroup canvasGroup;
    private Tween _fadeTween;
    [SerializeField] private readonly float _duration = 1; 
    private void OnEnable()
    {
        Fade(1f,_duration, () =>
        {
            canvasGroup.interactable = true;
            canvasGroup.blocksRaycasts = true;
        });
    }

    private void OnDisable()
    {
        Fade(0f,_duration,() =>
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
