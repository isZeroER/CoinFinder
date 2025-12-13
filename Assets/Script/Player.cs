using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("移动参数")]
    public float moveSpeed = 6f;
    public float jumpForce = 8f;
    public float gravity = 20f;
    
    [Header("地面检测")]
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    
    // 组件引用
    private CharacterController controller;
    private Animator animator;
    private Vector3 velocity;
    private bool isGrounded;
    
    // 状态变量
    private bool isAttacking = false;
    private bool isJumping = false;
    
    void Start()
    {
        // 获取组件引用
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        
        // 如果没有指定地面检测点，使用角色自身位置
        if (groundCheck == null)
            groundCheck = transform;
    }
    
    void Update()
    {
        // 检测是否在地面上
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        
        // 重置跳跃状态
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
            isJumping = false;
        }
        
        // 处理玩家输入
        HandleInput();
        
        // 应用重力
        if (!isGrounded)
        {
            velocity.y -= gravity * Time.deltaTime;
        }
        
        // 移动角色
        controller.Move(velocity * Time.deltaTime);
        
        // 更新动画参数
        UpdateAnimator();
    }
    
    void HandleInput()
    {
        // 如果在攻击中，不允许移动和跳跃（根据游戏设计可调整）
        if (isAttacking) return;
        
        // 移动输入
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        
        Vector3 move = transform.right * horizontal + transform.forward * vertical;
        controller.Move(moveSpeed * Time.deltaTime * move);
        
        // 跳跃输入
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            Jump();
        }
        
        // 攻击输入
        if (Input.GetButtonDown("Fire1"))
        {
            Attack();
        }
    }
    
    void Jump()
    {
        velocity.y = Mathf.Sqrt(jumpForce * 2f * gravity);
        isJumping = true;
        
        // 调用跳跃动画
        animator.SetTrigger("Jump");
    }
    
    void Attack()
    {
        isAttacking = true;
        
        // 调用攻击动画
        // animator.SetTrigger("Attack");
        
        // 重置攻击状态（根据动画长度决定）
        // 可以通过动画事件或协程来实现
        Invoke(nameof(ResetAttack), 0.5f); // 假设攻击动画长度为0.5秒
    }
    
    void ResetAttack()
    {
        isAttacking = false;
    }
    
    void UpdateAnimator()
    {
        // 计算移动速度（用于混合树）
        Vector3 horizontalVelocity = new Vector3(velocity.x, 0, velocity.z);
        float currentSpeed = horizontalVelocity.magnitude;
        
        // 设置动画参数
        if (animator != null)
        {
            // animator.SetFloat("Speed", currentSpeed);
            // animator.SetBool("IsGrounded", isGrounded);
            // animator.SetBool("IsAttacking", isAttacking);
        }
    }
    
    // 用于在Inspector中可视化地面检测范围
    void OnDrawGizmosSelected()
    {
        if (groundCheck != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(groundCheck.position, groundDistance);
        }
    }
}
