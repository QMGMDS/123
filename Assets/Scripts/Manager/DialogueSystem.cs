using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

//挂载在对话场景中Dialogue System身上的脚本
//作用:控制对话的进行
public class DialogueSystem : MonoBehaviour
{
    private PlayerInputControl playerControl;
    public TextMeshProUGUI contentDisplaybox; //对话显示处
    public DialugueSO dialugueSO; //对话内容
    public int dialugueOrder; //当前进行到对话几
    [Header("广播")]
    public DialogueEventSO dialogueEventSO; //用于结束对话,关闭对话框



    //对话系统一旦被触发,关闭原来人物控制的系统，进入对话模式操作
    private void Awake()
    {
        DisplayContentOnce();
        playerControl = new PlayerInputControl();
    }

    private void OnEnable()
    {
        playerControl.UI.Enable();
        playerControl.UI.Confirm.started += Confirm;
    }

    void OnDisable()
    {
        playerControl.UI.Disable();
        playerControl.UI.Confirm.started -= Confirm;
    }

    private void Confirm(InputAction.CallbackContext context) //按下E键确认,切换下一个对话
    {
        if (dialugueOrder < dialugueSO.dialogueLength - 1) //判断是否对话结束
        {
            dialugueOrder++;
            DisplayContentOnce();
        }
        else
        {
            Debug.Log("对话结束,结束对话框");
            dialugueOrder = 0; //重置对话
            PlayerStatusManager.instance.isDialogue = false; //退出对话状态
            dialogueEventSO.RaiseDialogueEvent(null, true); //关闭对话场景
        }
    }

    #region 显示对话dialugueOrder的内容
    private void DisplayContentOnce()
    {
        contentDisplaybox.text = dialugueSO.dialogue[dialugueOrder];
    }
    #endregion



}
