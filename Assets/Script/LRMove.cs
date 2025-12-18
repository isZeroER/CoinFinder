using UnityEngine;

public class LRMove : MonoBehaviour
{
    public float moveDistance = 2f;
    public float moveSpeed = 2f;

    private float lastOffset = 0f;

    void Update()
    {
        float offset = Mathf.Sin(Time.time * moveSpeed) * moveDistance;
        float delta = offset - lastOffset;

        // 沿自身右方向移动
        transform.Translate(0, 0, delta, Space.Self);

        lastOffset = offset;
    }
}