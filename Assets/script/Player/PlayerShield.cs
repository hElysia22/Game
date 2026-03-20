using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShield : MonoBehaviour
{
    public static bool isShieldUp; // 举盾状态
    private Animator _animator;

    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        // 右键控制举盾
        isShieldUp = Input.GetMouseButton(1);
        _animator.SetBool("shield", isShieldUp);
    }

    // 被敌人攻击时调用 → 播放盾受击动画
    public void PlayShieldHit()
    {
        if (isShieldUp) // 只有举盾时才能触发
        {
            _animator.ResetTrigger("shieldHit");
            _animator.SetTrigger("shieldHit");
        }
    }
}
