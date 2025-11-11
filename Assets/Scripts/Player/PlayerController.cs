using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private PlayerInputControl playerControl;
    private Rigidbody2D rb;

    [Header("移动方向")]
    public Vector2 inputDirection;
    [Header("移动速度")]
    public float speed;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        playerControl = new PlayerInputControl();
    }

    private void OnEnable()
    {
        playerControl.GamePlay.Enable();
    }

    private void OnDisable()
    {
        playerControl.Disable();
    }

    private void Update()
    {
        inputDirection = playerControl.GamePlay.Move.ReadValue<Vector2>(); //人物方向更新
    }

    private void FixedUpdate()
    {
        Move();
        
    }
    

    /// <summary>
    /// 人物移动
    /// </summary>
    void Move()
    {
        rb.velocity = inputDirection * speed * Time.deltaTime;
    }

}