using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMinin : enemyBase
{
    Animator animator;

    private void Awake()
    {
        base.Awake();
        animator = GetComponent<Animator>();
    }
    protected override void Die()
    {
        Debug.Log("小怪死亡");
        Destroy(gameObject);
    }

    private void Update()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.7f && animator.GetCurrentAnimatorStateInfo(0).IsName("Hit_F_1"))
        {
            animator.SetBool("Onhit", false);
        }
    }

    protected override void OnTakeDamage(int damage)
    {
        animator.SetBool("Onhit", true);
        Debug.Log("小怪受到伤害"+damage);
    }

}
