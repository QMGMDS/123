using UnityEngine;

//这是挂载在所有可战斗人物身上的脚本
//作用:保存人物基本信息
//人物信息处理的方法在这里(攻击等)
public class Attribute : MonoBehaviour
{
    public string characterName; //人物名称
    public int attack; //攻击值
    public int defence; //防御值
    public int maxHP; //最大血量值
    public int currentHP; //当前生命值




    #region 信息处理:攻击
    /// <summary>
    /// 由被攻击者调用 返回被攻击者是否死亡
    /// </summary>
    /// <param name="attackObject">攻击者的攻击值</param>
    /// <param name="defenceObject">被攻击者的防御值</param>
    public bool TakeDamage(int attackObject, int defenceObject)
    {
        int damege = attackObject - defenceObject;
        if (damege > 0)
        {
            currentHP -= damege;
        }
        if (currentHP <= 0)
        {
            return true;
        }
        return false;
    }
    #endregion


}
