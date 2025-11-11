using UnityEngine;
//创建对话内容文本的SO文件
[CreateAssetMenu(menuName = "Custom Container/DialogueSO")]
public class DialugueSO : ScriptableObject
{
    public string[] dialogue = { };
    public int dialogueLength;
}