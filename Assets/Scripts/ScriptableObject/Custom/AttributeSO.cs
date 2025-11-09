using UnityEngine;
[CreateAssetMenu(menuName = "Custom Container/CharactersAttributeSO")]

//记录所有角色属性信息的容器
//角色信息处理的方法也在这里
public class CharactersAttributeSO : ScriptableObject
{
    public string characterName;
    public int characterDefend;
    public int characterAttack;
    public int characterMaxHP;
    public int characterCurrentHP;

    #region 攻击
    public bool TakeDamage(int attackObject, int defenceObject)
    {
        int damege = attackObject - defenceObject;
        if (damege > 0)
        {
            characterCurrentHP -= damege;
        }
        if (characterCurrentHP <= 0)
        {
            return true;
        }
        return false;
    }
    #endregion
}
