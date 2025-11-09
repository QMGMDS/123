using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("事件监听")]
    public PlayAudioEventSO BGMEvent;
    public PlayAudioEventSO SEEvent;


    public AudioSource BGMSource;
    public AudioSource SESource;

    private void OnEnable()
    {
        SEEvent.OnAudioRaised += OnSEEvent;
        BGMEvent.OnAudioRaised += OnBGMEvent;

    }

    private void OnDisable()
    {
        SEEvent.OnAudioRaised -= OnSEEvent;
        BGMEvent.OnAudioRaised -= OnBGMEvent;
    }


    private void OnSEEvent(AudioClip audioClip)
    {
        SESource.clip = audioClip;
        SESource.Play();
    }

    private void OnBGMEvent(AudioClip audioClip)
    {
        BGMSource.clip = audioClip;
        BGMSource.Play();
    }
}
