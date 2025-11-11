using UnityEngine;
using UnityEngine.InputSystem;

//挂载在Player的子物体Sign身上的脚本
//作用:控制Sign子物体的动画
public class SignController : MonoBehaviour
{
    public GameObject problemSign; //问号提示物体
    private Animator anim;

    private void Awake()
    {
        //anim.GetComponentInChildren<Animator>(); 该方法在子物体激活时才能获取
        anim = problemSign.GetComponent<Animator>();
    }

    private void Update()
    {
        problemSign.GetComponent<SpriteRenderer>().enabled = PlayerStatusManager.instance.canInteract;
    }


    //遇到NPC，Player可交互(进入对话Player不可交互)
    private void OnTriggerStay2D(Collider2D NPCCollider)
    {
        if (NPCCollider.CompareTag("Interactable NPC") || NPCCollider.CompareTag("Businessman"))
        {
            PlayerStatusManager.instance.canInteract = true;
            SignChange(NPCCollider);
        }
    }
    //离开NPC，Player不可交互
    private void OnTriggerExit2D(Collider2D NPCCollider)
    {
        PlayerStatusManager.instance.canInteract = false;
    }






    /// <summary>
    ///不同提示不同动画
    /// </summary>
    /// <param name="NPCCollider"></param>
    private void SignChange(Collider2D NPCCollider)
    {
        switch (NPCCollider.tag)
        {
            case "Interactable NPC":
                anim.Play("problem");
                break;
            case "Businessman":
                anim.Play("amazing");
                break;
        }
    }
    
}
