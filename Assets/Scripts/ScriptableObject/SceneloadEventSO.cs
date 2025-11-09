using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName ="Event/SceneLoadEventSO")]
public class SceneloadEventSO : ScriptableObject
{
    public UnityAction<GameSceneSO, bool> LoadRequestEvent;  //监听


    /// <summary>
    /// 场景加载请求
    /// </summary>
    /// <param name="sceneToLoad">要加载的场景</param>
    /// <param name="fadeScreen">是否渐入渐出</param>
    public void RaiseLoadRequestEvent(GameSceneSO sceneToLoad, bool fadeScreen) //呼叫
    {
        LoadRequestEvent?.Invoke(sceneToLoad, fadeScreen);
    }
}
