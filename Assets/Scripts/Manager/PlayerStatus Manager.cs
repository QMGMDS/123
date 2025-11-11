using UnityEngine;

//挂载在PlayerStatus Manager身上的脚本
//作用：提供全局访问点，存储玩家角色所有的状态信息
public class PlayerStatusManager : MonoBehaviour
{
    #region 创建单例
    public static PlayerStatusManager instance;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    #endregion

    public bool isBattle; //战斗中？
    public bool canInteract; //可交互？
    public bool isDialogue; //对话中？



}
