using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterController : MonoBehaviour
{
    #region 组件获取
    Rigidbody2D rb;
    #endregion


    [Header("移动方向")]
    public Vector2 Direction;
    [Header("移动速度")]
    public float speed;
    public float currentSpeed;
    [Header("巡逻时长")]
    public float patrolTime;
    public float patrolWaitTime;
    [Header("计时器")]
    public float patrolTimeCounter;
    public float patrolWaitTimeCounter;
    [Header("怪物状态")]
    public bool wait;
    public bool battle; //是否战斗中?



    private void Awake()
    {
        #region 组件获取
        rb = GetComponent<Rigidbody2D>();
        #endregion

        #region 初始化
        patrolTimeCounter = patrolTime;
        patrolWaitTimeCounter = patrolWaitTime;
        currentSpeed = speed;
        #endregion
    }

    private void Update()
    {

        Timer();
    }

    private void FixedUpdate()
    {
        Move();
    }


    #region 怪物巡逻
    void Move()
    {
        rb.velocity = Direction * currentSpeed * Time.deltaTime;
    }
    #endregion

    #region 计时器

    #region 怪物巡逻计时器
    void Timer()
    {
        if (!wait)
        {
            patrolTimeCounter -= Time.deltaTime;
            if (patrolTimeCounter <= 0)
            {
                wait = true;       //巡逻结束进入等待
                currentSpeed = 0;        //进入等待,速度归零
                patrolTimeCounter = patrolTime;
            }
        }
        else
        {
            patrolWaitTimeCounter -= Time.deltaTime;
            if (patrolWaitTimeCounter <= 0)
            {
                Direction.y = -Direction.y;     //等待结束怪物转向
                currentSpeed = speed;       //等待结束，速度恢复
                wait = false;
                patrolWaitTimeCounter = patrolWaitTime;
            }
        }
    }
    #endregion

    #endregion
}
