using System;
using UnityEngine;
using UnityEngine.InputSystem;

//这是挂载在NPC的子物体Enter Dialogue身上的脚本
//作用:识别是否按下E键进行交互，向Dialogue Manager提交要加载的对话场景
public class TriggerDialogue : MonoBehaviour,IInteractable
{
    public DialogueSceneSO dialogueToLoad; //要加载的对话场景
    [Header("广播")]
    public DialogueEventSO dialogueEventSO;
    private PlayerInputControl playerControl;

    void Awake()
    {
        playerControl = new PlayerInputControl();
        playerControl.Enable();
    }

    void OnEnable()
    {
        playerControl.GamePlay.Confirm.started += EButtonPress;
    }

    void OnDisable()
    {
        playerControl.GamePlay.Confirm.started -= EButtonPress;

        playerControl.Disable();
    }



    private void EButtonPress(InputAction.CallbackContext context)
    {
        if (PlayerStatusManager.instance.canInteract)
        {
            TriggerInteraction();
        }
    }

    public void TriggerInteraction()
    {
        Debug.Log("进入对话!!!");
        PlayerStatusManager.instance.canInteract = false;
        PlayerStatusManager.instance.isDialogue = true;
        playerControl.Disable();
        dialogueEventSO.RaiseDialogueEvent(dialogueToLoad, true);
    }
}
