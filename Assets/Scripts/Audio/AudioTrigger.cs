using UnityEngine;

//这是挂载在Monster的子物体EnterBattle身上的脚本
//作用:触发进入战斗的提示音效

//待办:还没有为onTrigger复原回初始状态
public class AudioTrigger : MonoBehaviour
{
    public PlayAudioEventSO playAudioSE;
    public AudioClip audioSE;
    public bool onTrigger; //进入战斗的触发音效是否启用过?



    private void OnTriggerEnter2D(Collider2D playerCollider)
    {
        if (!onTrigger)
        {
            PlayAudioSE();
            onTrigger = true;
        }
    }


    #region 触发战斗音效
    public void PlayAudioSE()
    {
        playAudioSE.RaiseAudio(audioSE);
    }
    #endregion

}
