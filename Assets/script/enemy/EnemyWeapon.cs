using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeapon : MonoBehaviour
{
    public Animator _animator;
    private bool isAttack1 = false;

    void Update()
    {
        bool isPlayingAttack1 = _animator.GetCurrentAnimatorStateInfo(0).IsName("attack1");

        // 动画未播放 且 攻击标记为true → 重置
        if (!isPlayingAttack1 && isAttack1)
        {
            isAttack1 = false;
            Debug.Log("攻击动画1退出，重置状态");
        }
    }

    private void OnTriggerStay(Collider other)
    {
        PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
        if (playerHealth == null)
        {
            return;
        }
        if (!isAttack1 && _animator.GetCurrentAnimatorStateInfo(0).IsName("attack1") && _animator.GetCurrentAnimatorStateInfo(0).normalizedTime <= 0.5f)
        {
            isAttack1 = true;
            if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
            {
                Debug.Log("敌人攻击成功");
                playerHealth.TakeDamage(10);
            }
        }
    }

}
