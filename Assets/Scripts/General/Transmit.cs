using System.Collections;
using UnityEngine;

//这是挂载在Monster的子物体EnterBattle身上的脚本
//作用:向SceneLoad Manager提交去往的场景信息
public class Transmit : MonoBehaviour
{
    public GameSceneSO sceneToGo;
    [Header("广播")]
    public SceneloadEventSO SceneloadEventSO;
    public VoidEventSO cameraImpulse;


    private void OnTriggerEnter2D(Collider2D playerCollider)
    {
        StartCoroutine(BattleStart());
    }

    private IEnumerator BattleStart()
    {
        if (!PlayerStatusManager.instance.isBattle)
        {
            PlayerStatusManager.instance.isBattle = true; //人物进入战斗状态
            cameraImpulse.RaiseEvent(); //摄像机震动
            yield return new WaitForSeconds(0.2f);
            SceneloadEventSO.RaiseLoadRequestEvent(sceneToGo, false); //切换战斗场景
            Debug.Log("战斗开始!");
        }
    }
}
