using System;
using System.Collections;
using UnityEngine;

public class TanShe : MonoBehaviour
{
    [Header("弹射力度（给玩家）")]
    public float bounceForce = 12f;

    [Header("只允许从上方触发")]
    public float minDownVelocity = -0.1f;

    [Header("板子动画")]
    public Transform toTan;          // 要上下动的物体
    public float upHeight = 0.25f;    // 顶起高度
    public float upTime = 0.08f;      // 顶上去时间（快）
    public float downTime = 0.12f;    // 回位时间（慢）

    private Vector3 originPos;
    private bool isTanning = false;

    void Start()
    {
        if (toTan == null)
            toTan = transform;

        originPos = toTan.localPosition;
    }
    
    private void OnCollisionEnter(Collision other)
    {
        Player p = other.gameObject.GetComponent<Player>();
        if (!p) return;

        Rigidbody rb = p.rb;
        if (rb == null) return;

        // 播放板子动画
        if (!isTanning)
            StartCoroutine(CoTan());

        // 清空竖直速度，防止怪异叠加
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        // 向上弹射
        rb.AddForce(Vector3.up * bounceForce, ForceMode.Impulse);
    }

    IEnumerator CoTan()
    {
        isTanning = true;

        Vector3 upPos = originPos + Vector3.up * upHeight;

        // 1️⃣ 快速顶上去
        float t = 0f;
        while (t < upTime)
        {
            t += Time.deltaTime;
            toTan.localPosition = Vector3.Lerp(originPos, upPos, t / upTime);
            yield return null;
        }

        // 2️⃣ 慢慢回到原位
        t = 0f;
        while (t < downTime)
        {
            t += Time.deltaTime;
            toTan.localPosition = Vector3.Lerp(upPos, originPos, t / downTime);
            yield return null;
        }

        toTan.localPosition = originPos;
        isTanning = false;
    }
}