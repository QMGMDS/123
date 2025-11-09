using System.Collections;
using UnityEngine;

//挂载在物体Battle System上的脚本
//作用:掌管战斗中触发的音效
public class BattleSoundEffect : MonoBehaviour
{
    public PlayAudioEventSO playAudioSE;

    public AudioClip playerAttack;
    public AudioClip monsterAttack;



    #region 触发攻击音效
    public void TakeDamageAudio()
    {
        playAudioSE.RaiseAudio(playerAttack);
    }
    #endregion
}
