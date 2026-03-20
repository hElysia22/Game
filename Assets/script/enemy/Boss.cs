using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Boss : enemyBase
{
    private NavMeshAgent agent;
    private float attackReduis = 25f;
    private string playerTag = "Player";
    private float attackInterval = 5f;
    private float timer = 0;
    private bool isAttack = false;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    protected override void Update()
    {
        base.Update();
        if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.7f && animator.GetCurrentAnimatorStateInfo(0).IsName("attack2"))
        {
            animator.SetBool("isAttack2", false);
        }

        if (agent.velocity.magnitude > 0.01f)
        {
            OnMove(agent.velocity.x, agent.velocity.z);
        }
        else
        {
            OnMove(0, 0);
        }
        timer += Time.deltaTime;
        if (timer >= attackInterval)
        {
            timer = 0;
            isAttack = true;
        }
        if (isAttack)
        {
            Attack();
            isAttack = false;
        }
    }

    protected override void Attack()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, attackReduis);
        foreach (Collider collider in colliders)
        {
            if (collider.CompareTag(playerTag))
            {
                base.Attack();
                animator.SetBool("isAttack2", true);
                break;
            }
        }
    }

    protected override void Die()
    {
        Debug.Log("Boss死亡");
        Destroy(gameObject);
        //游戏结束

    }
    protected override void OnTakeDamage(int damage)
    {
        base.OnTakeDamage(damage);
        Debug.Log("boss 受到伤害" + damage);
    }
}
