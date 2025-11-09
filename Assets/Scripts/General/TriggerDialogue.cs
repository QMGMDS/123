using UnityEngine;

//这是挂载在NPC的子物体Enter Dialogue身上的脚本
//作用:向Dialogue Manager提交要加载的对话场景
public class TriggerDialogue : MonoBehaviour
{
    public DialogueEventSO dialogueEventSO;
    public GameSceneSO dialogueToGo; //要加载的对话场景

    private void Update()
    {
        DialogueTrigger();
    }


    private void DialogueTrigger()
    {
        if (PlayerController.Instance.dialogue && PlayerController.Instance.interaction)
        {
            dialogueEventSO.RaiseDialogueEvent(dialogueToGo, true); //呼叫:加载对话场景
            PlayerController.Instance.interaction = false; //关闭人物可交互状态
        }
    }
}
