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

    public float fadeDuration; //淡入淡出时长

    private bool isReturn; //是否复原先前场景

    [Header("事件监听")]
    public SceneloadEventSO sceneLoadEventSO;

    [Header("广播")]
    public FadeEventSO fadeEvent;

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

            isReturn = false;
            lastLoadScene = currentLoadScene;
            StartCoroutine(UnLoadCurrentScene());
        }
        else //传入空的场景,表明要退回先前的场景lastLoadScene
        {
            isReturn = true;

            Debug.Log("空空");
            this.fadeScreen = fadeScreen;
            StartCoroutine(UnLoadCurrentScene());
        }
    }


    #region 场景加载
    private IEnumerator UnLoadCurrentScene()
    {
        if (fadeScreen)
        {
            //变黑实现卸载场景
            fadeEvent.FadeIn(fadeDuration);
            yield return new WaitForSeconds(fadeDuration); //等待场景彻底变黑，再去卸载场景
        }

        currentLoadScene.sceneReference.UnLoadScene();
        Debug.Log("卸载了");

        if (isReturn)
        {
            LoadLastScene();
        }
        else
        {
            LoadNewScene();
        }
    }
    #endregion

    #region 加载新场景
    private void LoadNewScene()
    {
        if (fadeScreen)
        {
            fadeEvent.FadeOut(fadeDuration);
        }
        currentLoadScene = sceneToLoad;
        currentLoadScene.sceneReference.LoadSceneAsync(LoadSceneMode.Additive);
    }
    #endregion

    #region 加载历史场景
    private void LoadLastScene()
    {
        if (fadeScreen)
        {
            fadeEvent.FadeOut(fadeDuration);
        }
        currentLoadScene = lastLoadScene;
        lastLoadScene = sceneToLoad;
        currentLoadScene.sceneReference.LoadSceneAsync(LoadSceneMode.Additive);
    }
    #endregion

}
