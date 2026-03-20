using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon : MonoBehaviour
{
    private Animator _animator;
    private bool isAttack1 = false;
    private bool isAttack2 = false;
    private bool isAttack3 = false;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        bool isPlayingAttack1 = _animator.GetCurrentAnimatorStateInfo(0).IsName("attack1");
        bool isPlayingAttack2 = _animator.GetCurrentAnimatorStateInfo(0).IsName("attack2");
        bool isPlayingAttack3 = _animator.GetCurrentAnimatorStateInfo(0).IsName("attack3");
        // 动画未播放 且 攻击标记为true → 重置
        if (!isPlayingAttack1 && isAttack1)
        {
            isAttack1 = false;
            Debug.Log("攻击动画1退出，重置状态");
        }
        if (!isPlayingAttack2 && isAttack2)
        {
            isAttack2 = false;
            Debug.Log("攻击动画2退出，重置状态");
        }
        if (!isPlayingAttack3 && isAttack3)
        {
            isAttack3 = false;
            Debug.Log("攻击动画3退出，重置状态");
        }
    }

    private void OnTriggerStay(Collider other)
    {
        Debug.Log("是否命中Enemy层：" + (other.gameObject.layer == LayerMask.NameToLayer("Enemy")));
        enemyBase enemy = other.GetComponent<enemyBase>();
        if (enemy == null)
        {
            return;
        }
        if (!isAttack1 && _animator.GetCurrentAnimatorStateInfo(0).IsName("attack1") && _animator.GetCurrentAnimatorStateInfo(0).normalizedTime <= 0.5f)
        {
            isAttack1 = true;
            if (other.gameObject.layer == LayerMask.NameToLayer("Enemy"))
            {
                Debug.Log("攻击1成功");
                enemy.TakeDamage(10);
            }
        }
        if (!isAttack2 && _animator.GetCurrentAnimatorStateInfo(0).IsName("attack2") && _animator.GetCurrentAnimatorStateInfo(0).normalizedTime <= 0.5f)
        {
            isAttack2 = true;
            if (other.gameObject.layer == LayerMask.NameToLayer("Enemy"))
            {
                Debug.Log("攻击2成功");
                enemy.TakeDamage(12);
            }
        }
        if (!isAttack3 && _animator.GetCurrentAnimatorStateInfo(0).IsName("attack3") && _animator.GetCurrentAnimatorStateInfo(0).normalizedTime <= 0.5f)
        {
            isAttack3 = true;
            if (other.gameObject.layer == LayerMask.NameToLayer("Enemy"))
            {
                Debug.Log("攻击3成功");
                enemy.TakeDamage(15);
            }
        }
    }

    //接收角色的animator
    internal void setAnimator(Animator animator)
    {
        _animator = animator;
    }
}
