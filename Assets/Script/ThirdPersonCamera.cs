using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    public Transform target;

    public float distance = 4f;
    public float height = 1.5f;

    public float mouseSensitivity = 3f;
    public float minPitch = -30f;
    public float maxPitch = 60f;

    float yaw;
    float pitch;

    void Start()
    {
        Vector3 angles = transform.eulerAngles;
        yaw = angles.y;
        pitch = angles.x;
    }

    void LateUpdate()
    {
        if (!target) return;

        // 鼠标输入
        yaw += Input.GetAxis("Mouse X") * mouseSensitivity * 100f * Time.deltaTime;
        pitch -= Input.GetAxis("Mouse Y") * mouseSensitivity * 100f * Time.deltaTime;
        pitch = Mathf.Clamp(pitch, minPitch, maxPitch);

        // 相机旋转
        Quaternion camRotation = Quaternion.Euler(pitch, yaw, 0);
        transform.rotation = camRotation;

        // ⭐ 让玩家跟随相机 Y 轴旋转
        Quaternion playerRotation = Quaternion.Euler(0, yaw, 0);
        target.rotation = playerRotation;

        // 相机位置
        Vector3 targetPos = target.position + Vector3.up * height;
        transform.position = targetPos - camRotation * Vector3.forward * distance;
    }

}