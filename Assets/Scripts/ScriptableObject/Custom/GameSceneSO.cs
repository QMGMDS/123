using UnityEngine;
using UnityEngine.AddressableAssets;
[CreateAssetMenu(menuName = "Custom Container/GameSceneSO")]
public class GameSceneSO : ScriptableObject
{
    public SceneType sceneType;
    public AssetReference sceneReference;
}