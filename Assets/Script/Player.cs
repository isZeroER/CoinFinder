using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("移动参数")]
    public float moveSpeed = 6f;
    public float jumpForce = 8f;

    [Header("地面检测")]
    public Transform groundCheck;
    public float groundDistance = 0.3f;
    public LayerMask groundMask;

    // 组件
    private Rigidbody rb;
    private Animator animator;

    // 状态
    private bool isGrounded;
    private bool isAttacking;
    private bool isDead;

    private Vector3 moveInput;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();

        if (groundCheck == null)
            groundCheck = transform;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            UIController.Instance.SetFalse();
        }
        if (isDead) return;

        CheckGround();
        HandleInput();
        UpdateAnimator();
    }

    void FixedUpdate()
    {
        if (isDead || isAttacking) return;

        Move();
    }

    // =========================
    // 输入
    // =========================
    void HandleInput()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        moveInput = new Vector3(h, 0, v);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            Jump();
        }

        if (Input.GetButtonDown("Fire1"))
        {
            Attack();
        }
    }

    // =========================
    // 移动
    // =========================
    void Move()
    {
        Vector3 moveDir = transform.TransformDirection(moveInput);
        Vector3 targetVelocity = moveDir * moveSpeed;
        targetVelocity.y = rb.velocity.y;

        rb.velocity = targetVelocity;
    }

    void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

        animator.SetTrigger("Jump");
    }

    // =========================
    // 攻击
    // =========================
    void Attack()
    {
        if (isAttacking) return;

        isAttacking = true;
        animator.SetBool("IsAttacking", true);

        Invoke(nameof(ResetAttack), 0.5f);
    }

    void ResetAttack()
    {
        isAttacking = false;
        animator.SetBool("IsAttacking", false);
    }

    // =========================
    // 地面检测
    // =========================
    void CheckGround()
    {
        isGrounded = Physics.CheckSphere(
            groundCheck.position,
            groundDistance,
            groundMask
        );
    }

    // =========================
    // Animator
    // =========================
    void UpdateAnimator()
    {
        Vector3 horizontalVelocity = rb.velocity;
        horizontalVelocity.y = 0;

        animator.SetFloat("Speed", horizontalVelocity.magnitude);
        animator.SetBool("IsGrounded", isGrounded);
    }

    // =========================
    // 死亡
    // =========================
    public void SetDie()
    {
        isDead = true;
        rb.velocity = Vector3.zero;
    }
}
