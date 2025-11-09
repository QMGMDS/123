using UnityEngine;
using UnityEngine.SceneManagement;

//挂载在Dialogue Manager身上的脚本
//作用:将监听到的对话场景加载出来
public class DialogueManager : MonoBehaviour
{
    public GameSceneSO currentDialogue; //显示当前加载的对话场景

    private bool fadeScreen;

    [Header("事件监听")]
    public DialogueEventSO dialogueEventSO;



    private void OnEnable()
    {
        dialogueEventSO.LoadDialogue += loadDialogue;
    }

    private void OnDisable()
    {
        dialogueEventSO.LoadDialogue -= loadDialogue;
    }

    private void loadDialogue(GameSceneSO dialogueToLoad, bool fadeScreen)  //事件监听
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
        currentDialogue.sceneReference.LoadSceneAsync(LoadSceneMode.Additive);
    }

    //卸载当前对话场景
    private void DeleteCurrentDialogue()
    {
        currentDialogue.sceneReference.UnLoadScene();
    }
}
