using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName ="Event/FadeEventSO")]
public class FadeEventSO : ScriptableObject
{
    public UnityAction<Color, float> OnEventRaised;


    /// <summary>
    ///画面逐渐变黑
    /// </summary>
    /// <param name="duration"></param>
    public void FadeIn(float duration)
    {
        RaiseEvent(Color.black, duration);
    }

    /// <summary>
    /// 画面逐渐变透明
    /// </summary>
    /// <param name="duration"></param>
    public void FadeOut(float duration)
    {
        RaiseEvent(Color.clear, duration);
    }
    

    public void RaiseEvent(Color target,float duration)
    {
        OnEventRaised?.Invoke(target, duration);
    }

}
