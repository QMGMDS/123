using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance {get; private set;}       //提供全局访问点,可以全局直接访问PlayerController里面的信息

    #region 激活输入系统
    public PlayerInputControl inputControl;
    #endregion
    #region 组件获取
    Rigidbody2D rb;
    #endregion

    [Header("移动方向")]
    public Vector2 inputDirection;
    [Header("移动速度")]
    public float speed;
    [Header("人物状态")]
    public bool battle; //是否战斗中?
    public bool interaction; //是否可交互?
    public bool dialogue;  //是否对话中?


    private void Awake()
    {
        Instance = this;

        #region 组件获取
        rb = GetComponent<Rigidbody2D>();
        #endregion
        #region 激活输入系统
        inputControl = new PlayerInputControl();
        inputControl.Enable();
        #endregion
    }

    private void OnEnable()
    {
        #region 按键交互
        inputControl.GamePlay.Interaction.started += EInteract; //人物交互-E键对话
        #endregion
    }

    private void Update()
    {
        inputDirection = inputControl.GamePlay.Move.ReadValue<Vector2>(); //人物方向更新
        

    }

    private void FixedUpdate()
    {
        Move();
        
    }

    private void OnDisable()
    {
        #region 关闭输入系统
        inputControl.Disable();
        #endregion
        inputControl.GamePlay.Interaction.started -= EInteract;
    }

    #region 人物移动
    void Move()
    {
        rb.velocity = inputDirection * speed * Time.deltaTime;
    }
    #endregion

    #region E键-交互
    private void EInteract(InputAction.CallbackContext context)
    {
        if (interaction)
        {
            Debug.Log("交互了");
            //对话框
            dialogue = true;
        }
    }
    #endregion
}