using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeapon : MonoBehaviour
{
    public Animator _animator;
    private bool isAttack1 = false;
    private bool isAttack2 = false;

    void Update()
    {
        bool isPlayingAttack1 = _animator.GetCurrentAnimatorStateInfo(0).IsName("attack1");
        bool isPlayingAttack2 = _animator.GetCurrentAnimatorStateInfo(0).IsName("attack2");

        // 动画未播放 且 攻击标记为true → 重置  避免一段攻击多段伤害
        if (!isPlayingAttack1 && isAttack1)
        {
            isAttack1 = false;
            Debug.Log("敌人攻击动画1退出，重置状态");
        }
        if (!isPlayingAttack2 && isAttack2)
        {
            isAttack2 = false;
            Debug.Log("敌人攻击动画2退出，重置状态");
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
                PlayerShield playerShield = other.GetComponentInParent<PlayerShield>();

                if (playerShield != null && PlayerShield.isShieldUp)
                {
                    playerShield.PlayShieldHit();
                    Debug.Log("盾牌格挡成功 → 播放 shieldHit 动画");
                }
                else
                {
                    Debug.Log("命中玩家 → 掉血");
                    playerHealth.TakeDamage(20);
                }
            }
        }
        if (!isAttack2 && _animator.GetCurrentAnimatorStateInfo(0).IsName("attack2") && _animator.GetCurrentAnimatorStateInfo(0).normalizedTime <= 0.5f)
        {
            isAttack2 = true;
            if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
            {
                PlayerShield playerShield = other.GetComponentInParent<PlayerShield>();

                if (playerShield != null && PlayerShield.isShieldUp)
                {
                    playerShield.PlayShieldHit();
                    Debug.Log("盾牌格挡成功 → 播放 shieldHit 动画");
                }
                else
                {
                    Debug.Log("命中玩家 → 掉血");
                    playerHealth.TakeDamage(20);
                }
            }
        }
    }

}
