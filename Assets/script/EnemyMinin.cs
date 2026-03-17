using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.GraphicsBuffer;

public class EnemyMinin : enemyBase
{
    private NavMeshAgent agent;
    private float attackReduis = 17f;
    private string playerTag = "Player";
    private float attackInterval = 6f;
    private float timer = 0;
    private bool isAttack = false;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    protected override void Update()
    {
        base.Update();
        if(agent.velocity.magnitude > 0.01f)
        {
            OnMove(agent.velocity.x, agent.velocity.z);
        }
        else
        {
            OnMove(0, 0);
        }
        timer += Time.deltaTime;
        if(timer >= attackInterval)
        {
            timer = 0;
            isAttack = true;
        }
        if(isAttack)
        {
            Attack();
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
                break;
            }
        }
    }

    protected override void Die()
    {
        Debug.Log("小怪死亡");
        Destroy(gameObject);
    }


    protected override void OnTakeDamage(int damage)
    {
        base.OnTakeDamage(damage);
        Debug.Log("小怪受到伤害"+damage);
    }

}
