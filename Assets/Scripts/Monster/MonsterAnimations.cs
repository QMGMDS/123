using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAnimations : MonoBehaviour
{
    #region 组件获取
    MonsterController monsterController;
    Animator anim;
    #endregion

    private void Awake()
    {
        #region 组件获取
        monsterController = GetComponent<MonsterController>();
        anim = GetComponent<Animator>();
        #endregion

    }

    private void Update()
    {
        Move();
    }


    #region 静止+移动动画
    void Move()
    {
        //怪物静止动画
        if (monsterController.Direction.x != 0 && monsterController.currentSpeed != 0)
        {
            anim.SetFloat("X", monsterController.Direction.x);
            anim.SetFloat("Y", 0);
        }
        if (monsterController.Direction.y != 0 && monsterController.currentSpeed != 0)
        {
            anim.SetFloat("Y", monsterController.Direction.y);
            anim.SetFloat("X", 0);
        }

        anim.SetFloat("Speed", monsterController.currentSpeed);

    }
    #endregion

}
