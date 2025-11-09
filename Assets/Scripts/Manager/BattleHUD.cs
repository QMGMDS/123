using TMPro;
using UnityEngine;
using UnityEngine.UI;

//挂载在Battle场景画布中子物体HUD上
//作用:将人物信息实时可视化
public class BattleHUD : MonoBehaviour
{
    public TextMeshProUGUI nameText; //名字
    public Slider hpSlider; //血条

    //


    //显示人物信息
    public void SetHUD(CharactersAttributeSO charactersAttribute)
    {
        nameText.text = charactersAttribute.characterName;
        hpSlider.maxValue = charactersAttribute.characterMaxHP;
        hpSlider.value = charactersAttribute.characterCurrentHP;
    }

    //实时更新血量
    public void UpdateHP(int currentHP)
    {
        hpSlider.value = currentHP;
    }
}
