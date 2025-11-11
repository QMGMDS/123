using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.InputSystem.LowLevel.InputEventTrace;

public class PlayerAnimations : MonoBehaviour
{
	private PlayerController playerController;
    private Animator anim;

    private void Awake()
    {
        playerController = GetComponent<PlayerController>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        Move();
    }


    #region 静止+移动动画
    void Move()
    {
        //人物静止动画
        if (playerController.inputDirection.x != 0)
        {
            anim.SetFloat("X", playerController.inputDirection.x);
            anim.SetFloat("Y", 0);
        }
        if (playerController.inputDirection.y != 0)
        {
            anim.SetFloat("Y", playerController.inputDirection.y);
            anim.SetFloat("X", 0);
        }

        anim.SetFloat("Speed", playerController.inputDirection.magnitude);
        #region magnitude解释
        //magnitude表示计算该向量的长度,若是二维向量(x,y),则计算结果为x的平方与y的平方和的二分之一次幂
        #endregion

    }
    #endregion

}
