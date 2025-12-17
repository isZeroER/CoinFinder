using UnityEngine;

public class UpDown : MonoBehaviour
{
    [Header("浮动参数")]
    public float amplitude = 1.5f;   // 上下高度
    public float speed = 2f;         // 浮动速度

    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void FixedUpdate()
    {
        float yOffset = Mathf.Sin(Time.time * speed) * amplitude;
        transform.position = startPos + Vector3.up * yOffset;
    }
}