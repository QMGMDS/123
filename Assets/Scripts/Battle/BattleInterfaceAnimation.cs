using UnityEngine;

//挂载在物体Battle System上的脚本
//掌管回合制战斗界面的动画逻辑
public class BattleInterfaceAnimation : MonoBehaviour
{
	public GameObject attacking;
	public GameObject playerBattleHUD;
	public GameObject monsterBattleHUD;

	#region 进入预攻击状态
	public void ReadyToAttack()
	{
		attacking.SetActive(true);
		playerBattleHUD.SetActive(false);
		monsterBattleHUD.SetActive(true);
	}
    #endregion

    #region 退出预攻击状态
    public void QuitReadyAttack()
    {
        attacking.SetActive(false);
        playerBattleHUD.SetActive(true);
        monsterBattleHUD.SetActive(false);
    }
    #endregion
}
