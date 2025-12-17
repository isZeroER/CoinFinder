using System.Collections;
using UnityEngine;

public class JianCiController : MonoBehaviour
{
    public Transform jianci;

    [Header("时间参数")]
    public float firstTime = 1f;
    public float waitTimer = 1.5f;
    public float extendTime = 0.15f;   // 刺出时间
    public float stayTime = 0.3f;      // 停留时间
    public float retractTime = 0.2f;   // 收回时间

    [Header("高度参数")]
    public float extendHeight = 1.2f;

    private Vector3 originPos;

    void Start()
    {
        originPos = jianci.localPosition;
        StartCoroutine(CoJianCi());
    }

    IEnumerator CoJianCi()
    {
        yield return new WaitForSeconds(firstTime);
        while (true)
        {
            // 等待
            yield return new WaitForSeconds(waitTimer);

            // 刺出
            yield return MoveY(originPos, originPos + Vector3.up * extendHeight, extendTime);

            // 停留（危险时间）
            yield return new WaitForSeconds(stayTime);

            // 收回
            yield return MoveY(originPos + Vector3.up * extendHeight, originPos, retractTime);
        }
    }

    IEnumerator MoveY(Vector3 from, Vector3 to, float time)
    {
        float t = 0f;
        while (t < time)
        {
            t += Time.deltaTime;
            jianci.localPosition = Vector3.Lerp(from, to, t / time);
            yield return null;
        }
        jianci.localPosition = to;
    }
}