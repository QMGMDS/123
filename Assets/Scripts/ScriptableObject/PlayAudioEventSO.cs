using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName ="Event/PlayAudioEventSO")]
public class PlayAudioEventSO : ScriptableObject
{
    public UnityAction<AudioClip> OnAudioRaised;

    public void RaiseAudio(AudioClip audioClip)
    {
        OnAudioRaised?.Invoke(audioClip);
    }
}
