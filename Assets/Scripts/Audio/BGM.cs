using UnityEngine;

//这是挂载在场景中的脚本,在场景被激活时启用
//作用:向Audio Manager提交该场景要播放的BGM
public class BGM : MonoBehaviour
{
    [Header("事件监听")]
    public PlayAudioEventSO playAudioEvent;


    public AudioClip audioClip; //要播放的场景BGM

    private void OnEnable()
    {
        PlayAudioClip(); //场景一被激活就播放该场景的背景音乐
    }

    public void PlayAudioClip()
    {
        playAudioEvent.RaiseAudio(audioClip);
    }
}
