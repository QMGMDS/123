using UnityEngine;
using UnityEngine.Events;


[CreateAssetMenu(menuName = "Event/DialogueEventSO")]
public class DialogueEventSO : ScriptableObject
{
    public UnityAction<GameSceneSO, bool> LoadDialogue;  //监听


    /// <summary>
    /// 对话框加载请求
    /// </summary>
    /// <param name="DialogueToLoad">要加载的对话框</param>
    /// <param name="fadeScreen">是否渐入渐出</param>
    public void RaiseDialogueEvent(GameSceneSO dialogueToLoad, bool fadeScreen) //呼叫
    {
        LoadDialogue?.Invoke(dialogueToLoad, fadeScreen);
    }
}
