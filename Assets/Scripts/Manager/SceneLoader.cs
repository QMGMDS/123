using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

//挂载在SceneLoad Manager身上的脚本
//作用:控制场景的加载和切换
public class SceneLoader : MonoBehaviour
{
    public GameSceneSO firstLoadScene;
    public GameSceneSO currentLoadScene;
    public GameSceneSO lastLoadScene; //保存上一个被加载的场景

    [Header("事件监听")]
    public SceneloadEventSO sceneLoadEventSO;

    //接收
    private GameSceneSO sceneToLoad;
    private bool fadeScreen;

    private void Awake()
    {
        currentLoadScene = firstLoadScene;
        currentLoadScene.sceneReference.LoadSceneAsync(LoadSceneMode.Additive);
    }

    private void OnEnable()
    {
        sceneLoadEventSO.LoadRequestEvent += OnLoadRequestEvent;
    }

    private void OnDisable()
    {
        sceneLoadEventSO.LoadRequestEvent -= OnLoadRequestEvent;
    }

    private void OnLoadRequestEvent(GameSceneSO sceneToLoad, bool fadeScreen)
    {
        if (sceneToLoad != null)
        {
            //接收
            this.sceneToLoad = sceneToLoad;
            this.fadeScreen = fadeScreen;

            lastLoadScene = currentLoadScene;
            StartCoroutine(UnLoadCurrentScene());
            LoadNewScene();
        }
        else //传入空的场景,表明要退回先前的场景lastLoadScene
        {
            Debug.Log("空空");
            this.fadeScreen = fadeScreen;
            StartCoroutine(UnLoadCurrentScene());
            LoadLastScene();
        }
    }


    #region 卸载当前场景
    private IEnumerator UnLoadCurrentScene()
    {
        if (fadeScreen)
        {
            //渐入渐出效果
        }
        yield return currentLoadScene.sceneReference.UnLoadScene();
        Debug.Log("卸载了");
    }
    #endregion

    #region 加载新场景
    private void LoadNewScene()
    {
        currentLoadScene = sceneToLoad;
        currentLoadScene.sceneReference.LoadSceneAsync(LoadSceneMode.Additive);
    }
    #endregion

    #region 加载历史场景
    private void LoadLastScene()
    {
        currentLoadScene = lastLoadScene;
        lastLoadScene = sceneToLoad;
        currentLoadScene.sceneReference.LoadSceneAsync(LoadSceneMode.Additive);
    }
    #endregion

}
