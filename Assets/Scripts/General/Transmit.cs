using UnityEngine;

//这是挂载在Monster的子物体EnterBattle身上的脚本
//作用:向SceneLoad Manager提交去往的场景信息
public class Transmit : MonoBehaviour
{
    public SceneloadEventSO SceneloadEventSO;
    public GameSceneSO sceneToGo;

    private void OnTriggerEnter2D(Collider2D playerCollider)
    {
        if (!PlayerController.Instance.battle)
        {
            PlayerController.Instance.battle = true; //人物进入战斗状态
            SceneloadEventSO.RaiseLoadRequestEvent(sceneToGo, true); //切换战斗场景
            Debug.Log("战斗开始!");
        }
    }
}
