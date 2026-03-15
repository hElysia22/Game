using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    Rigidbody rb;
    public float moveSpeed;
    public float runSpeed;
    public float turnSpeed = 10f;
    private Animator _animator;
    private bool _isRunning = false;
    private Vector3 _velocity;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        // 物理相关逻辑必须放在FixedUpdate
        HandleMovement();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            _isRunning = true;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            _isRunning = false;
        }
    }

    private void HandleMovement()
    {
        // 1. 获取WASD/方向键输入
        float horizontal = Input.GetAxis("Horizontal"); // A/D → -1/1
        float vertical = Input.GetAxis("Vertical"); // W/S → 1/-1

        // 2. 归一化输入（避免斜向移动速度更快）
        Vector3 inputDir = new Vector3(horizontal, 0f, vertical).normalized;
        if(_isRunning)
        {
             _velocity = new Vector3(horizontal, 0f, vertical) * runSpeed;
        }
        else
        {
            _velocity = new Vector3(horizontal, 0f, vertical) * moveSpeed;
        }
        

        if (_velocity.magnitude > 0.01f) // 有有效输入时才处理移动
        {
            // 3. 计算基于相机水平朝向的移动方向（将玩家的本地输入方向，转换为相机视角下的世界方向）物体旋转在camera代码里写了,这里直接引用物体自身朝向
            Vector3 moveDir = Quaternion.Euler(0f, transform.eulerAngles.y, 0f) * inputDir;

            // 4. 设置刚体速度（只修改X/Z轴，Y轴保持0，避免浮空/下沉）
            if (_isRunning)
            {
                rb.velocity = new Vector3(moveDir.x * runSpeed, 0f, moveDir.z * runSpeed);
            }
            else
            {
                rb.velocity = new Vector3(moveDir.x * moveSpeed, 0f, moveDir.z * moveSpeed);
            }
            _animator.SetFloat("v_h", _velocity.x);
            _animator.SetFloat("v_v", _velocity.z);
        }
        else
        {
            // 无输入时停止移动（重置X/Z轴速度）
            rb.velocity = new Vector3(0f, 0f, 0f);
            _animator.SetFloat("v_h", _velocity.x);
            _animator.SetFloat("v_v", _velocity.z);
        }
    }
}
