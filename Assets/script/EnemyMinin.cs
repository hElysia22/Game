using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMinin : enemyBase
{
    private NavMeshAgent agent;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    protected override void Update()
    {
        base.Update();
        //目前存在问题：水平方向速度还未解决
        if(agent.velocity.magnitude > 0.01f)
        {
            OnMove(agent.velocity.x, agent.velocity.z);
        }
        else
        {
            OnMove(0, 0);
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
