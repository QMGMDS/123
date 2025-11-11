using UnityEngine;
using UnityEngine.SceneManagement;

//挂载在Dialogue Manager身上的脚本
//作用:控制对话场景的加载和卸载
public class DialogueManager : MonoBehaviour
{
    public DialogueSceneSO currentDialogue; //显示当前加载的对话场景

    private bool fadeScreen;

    [Header("事件监听")]
    public DialogueEventSO dialogueEventSO;



    private void OnEnable()
    {
        dialogueEventSO.LoadDialogue += LoadDialogue;
    }

    private void OnDisable()
    {
        dialogueEventSO.LoadDialogue -= LoadDialogue;
    }

    private void LoadDialogue(DialogueSceneSO dialogueToLoad, bool fadeScreen)  //事件监听
    {
        if (dialogueToLoad != null)
        {
            currentDialogue = dialogueToLoad;
            this.fadeScreen = fadeScreen;
            LoadNewDialogue();
        }
        else //如果传入空的对话场景,则卸载当前的对话场景
        {
            Debug.Log("空");
            this.fadeScreen = fadeScreen;
            DeleteCurrentDialogue();
        }
    }

    //加载对话场景
    private void LoadNewDialogue()
    {
        currentDialogue.DialogueSceneReference.LoadSceneAsync(LoadSceneMode.Additive);
    }

    //卸载当前对话场景
    private void DeleteCurrentDialogue()
    {
        currentDialogue.DialogueSceneReference.UnLoadScene();
    }
}
