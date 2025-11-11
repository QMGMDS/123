using UnityEngine;
using UnityEngine.AddressableAssets;
//创建对话场景的SO文件
[CreateAssetMenu(menuName = "Custom Container/DialogueSceneSO")]
public class DialogueSceneSO : ScriptableObject
{
    public AssetReference DialogueSceneReference;
}
