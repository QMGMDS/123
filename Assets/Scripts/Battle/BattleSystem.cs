using System.Collections;
using UnityEngine;


//挂载在Battle System身上的脚本
//作用:实现整个回合制战斗的逻辑
public class BattleSystem : MonoBehaviour
{
    public BattleState state; //回合状态
    public CharactersAttributeSO playerAttribute; //玩家信息
    public CharactersAttributeSO monsterAttribute; //怪物信息
    [Header("人物界面")]
    public BattleHUD playerHUD;
    public BattleHUD monsterHUD;

    public SceneloadEventSO SceneloadEventSO; //用于切换场景

    private void Start()
    {
        state = BattleState.Start;
        StartCoroutine(BattleStart());
    }

    #region 战斗开始前的准备
    private IEnumerator BattleStart() //携程使该方法的执行中可以延时
    {
        playerHUD.SetHUD(playerAttribute);
        monsterHUD.SetHUD(monsterAttribute);

        Debug.Log("怪物出现了");
        yield return new WaitForSeconds(1f);
        state = BattleState.PlayerTurn;
    }
    #endregion

    #region 玩家回合
    public void PlayerAttack()
    {
        bool isDefeated = monsterAttribute.TakeDamage(playerAttribute.characterAttack, monsterAttribute.characterDefend);
        monsterHUD.UpdateHP(monsterAttribute.characterCurrentHP);
        if (isDefeated)
        {
            //战斗结束
            state = BattleState.Won;
            EndBattle();
        }
        else
        {
            //怪物回合
            state = BattleState.MonsterTurn;
            MonsterTurn();
        }
    }
    #endregion

    #region 怪物回合
    public void MonsterTurn()
    {
        bool isDefeated = playerAttribute.TakeDamage(monsterAttribute.characterAttack, playerAttribute.characterDefend);
        playerHUD.UpdateHP(playerAttribute.characterCurrentHP);

        if (isDefeated)
        {
            //战斗结束
            state = BattleState.Lost;
            EndBattle();
        }
        else
        {
            //玩家回合
            state = BattleState.PlayerTurn;
        }
    }
    #endregion

    #region 战斗结束
    public void EndBattle()
    {
        if (state == BattleState.Won)
        {
            Debug.Log("玩家胜利");
        }
        else if (state == BattleState.Lost)
        {
            Debug.Log("怪物胜利");
        }

        PlayerController.Instance.battle = false;
        SceneloadEventSO.RaiseLoadRequestEvent(null, true); //回到进入战斗之前的场景
    }
    #endregion

}