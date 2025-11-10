using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine;

public class FadeCanvas : MonoBehaviour
{
    public Image fadeImage;

    [Header("事件监听")]
    public FadeEventSO fadeEvent;

    void OnEnable()
    {
        fadeEvent.OnEventRaised += OnFadeEvent;
    }

    void OnDisable()
    {
        fadeEvent.OnEventRaised += OnFadeEvent;
    }

    private void OnFadeEvent(Color target, float duration)
    {
        fadeImage.DOBlendableColor(target, duration);
    }
}
