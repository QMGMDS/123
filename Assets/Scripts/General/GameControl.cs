using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作用：控制Player的所有行为
public class GameControl : MonoBehaviour
{
    public PlayerInputControl playerControl;
    public GameObject player;
    private Rigidbody2D playerRigibody2D;

    [Header("移动方向")]
    public Vector2 inputDirection;
    [Header("移动速度")]
    public float speed;


    private void Awake()
    {
        playerControl = new PlayerInputControl();
        playerControl.Enable();
        playerRigibody2D = player.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        inputDirection = playerControl.GamePlay.Move.ReadValue<Vector2>(); //人物方向更新
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void OnDisable()
    {
        playerControl.Disable();
    }

    #region 人物移动
     void Move()
     {
         playerRigibody2D.velocity = inputDirection * speed * Time.deltaTime;
     }
    #endregion

}
