using UnityEngine;

//挂载在Player的子物体InteractionTips身上的脚本
//作用:控制InteractionTips的子物体的激活和关闭
public class SignController : MonoBehaviour
{
    public GameObject problemSign; //问号提示物体


    private void Update()
    {
        OpenProblemSign();
    }

    private void OpenProblemSign() //控制问号提示物体的激活和关闭
    {
        if (PlayerController.Instance.interaction)
        {
            problemSign.SetActive(true);
        }
        else
        {
            problemSign.SetActive(false);
        }
    }

    //遇到NPC,Player可交互(进入对话Player不可交互)
    private void OnTriggerEnter2D(Collider2D NPCCollider)
    {
        if (NPCCollider.gameObject.layer == 8) //NPC的Layer为8
        {
            PlayerController.Instance.interaction = true;
        }
    }

}
