using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    [Header("跟随目标")]
    public Transform target; // 相机跟随的目标（比如玩家）
    [Header("跟随目标点")]
    public Transform followTarget;
    [Header("相机参数")]
    public float distance = 5.0f; // 相机到目标的距离
    public float sensitivity = 2.0f; // 鼠标灵敏度
    public float minVerticalAngle = -30f; // 垂直旋转最小角度（防止低头过度）
    public float maxVerticalAngle = 60f; // 垂直旋转最大角度（防止抬头过度）

    private float currentX; // 水平旋转角度
    private float currentY; // 垂直旋转角度

    public float turnSpeed = 10f;

    private void Start()
    {
        // 隐藏并锁定鼠标光标（可选，根据需求调整）
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        // 初始化角度为相机当前角度
        Vector3 angles = transform.eulerAngles;
        currentX = angles.y;
        currentY = angles.x;
    }

    private void LateUpdate()
    {
        if (target == null) return; // 防止空引用

        // 获取鼠标移动增量
        currentX += Input.GetAxis("Mouse X") * sensitivity;
        currentY -= Input.GetAxis("Mouse Y") * sensitivity; // 减号让鼠标上移时相机抬头

        // 限制垂直旋转角度，避免翻转
        currentY = Mathf.Clamp(currentY, minVerticalAngle, maxVerticalAngle);

        // 计算相机旋转
        Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);
        //计算相机与目标的距离
        Vector3 position = rotation * new Vector3(0, 0, -distance) + followTarget.position;

        // 应用到相机
        transform.rotation = rotation;
        transform.position = position;
    }

    // 可选：按ESC显示鼠标
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    void FixedUpdate()
    {
        //物体跟随相机旋转
        float playerCamera = transform.rotation.eulerAngles.y;
        target.rotation = Quaternion.Slerp(target.rotation, Quaternion.Euler(0, playerCamera, 0), turnSpeed);
    }
}