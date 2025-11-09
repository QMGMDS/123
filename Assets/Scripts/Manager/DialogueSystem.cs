using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

//挂载在对话场景中Dialogue System身上的脚本
//作用:控制对话的进行
public class DialogueSystem : MonoBehaviour
{
    public DialogueEventSO dialogueEventSO; //用于结束对话,关闭对话框


    public TextMeshProUGUI contentDisplaybox; //对话显示处
    public DialugueSO dialugueSO; //对话内容

    public int dialugueOrder; //当前进行到对话几

    //对话系统一旦被触发,关闭原来人物控制的系统，进入对话模式操作
    private void Awake()
    {
        PlayerController.Instance.inputControl.GamePlay.Disable();
        DisplayContentOnce();
    }

    private void OnEnable()
    {
        PlayerController.Instance.inputControl.UI.Confirm.started += Confirm;
    }

    private void OnDisable()
    {
        PlayerController.Instance.inputControl.UI.Confirm.started -= Confirm;
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
            PlayerController.Instance.dialogue = false; //退出对话状态
            dialogueEventSO.RaiseDialogueEvent(null, true); //关闭对话场景
            PlayerController.Instance.inputControl.GamePlay.Enable(); //开启GamePlay控制模式
        }
    }

    #region 显示对话dialugueOrder的内容
    private void DisplayContentOnce()
    {
        contentDisplaybox.text = dialugueSO.dialogue[dialugueOrder];
    }
    #endregion



}
