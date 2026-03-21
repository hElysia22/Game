using UnityEngine;
using UnityEngine.AI;

public class EnemyNav : MonoBehaviour
{
    private Transform target;
    private NavMeshAgent agent;
    public float searchRadius = 70f;
    private string playerTag = "Player";
    private float timer = 0;
    private float moveSpeed = 20f;
    private float stopDis = 0f;
    //巡逻点
    public Transform[] PatrolPoint;
    private int currentPoint = 0;
    private bool isReadyToSwitch = true; // 防止频繁切换

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    } 

    private void Update()
    {
            SearchPlayer();
            timer = 0;
            if(target != null)
            {
                stopDis = 20f;
                agent.stoppingDistance = stopDis;
                if(Vector3.Distance(transform.position, target.position) > agent.stoppingDistance)
                {
                    agent.speed = moveSpeed;
                    agent.SetDestination(target.position);
                }
                else
                {
                    agent.speed = 0;
                    agent.ResetPath();
                }
            }
            else
            {
                if(PatrolPoint.Length != 0)
                {
                   AIPatrol();
                }
                else
                {
                    agent.speed = 0;
                    agent.ResetPath();
                }
            } 
    }

    private void AIPatrol()
    {
        agent.speed = moveSpeed;
        stopDis = 0.1f;
        agent.stoppingDistance = stopDis;
        agent.SetDestination(PatrolPoint[currentPoint].position);
        Debug.Log("距离" + Vector3.Distance(transform.position, PatrolPoint[currentPoint].position));
        if (isReadyToSwitch && agent.remainingDistance <= agent.stoppingDistance && !agent.pathPending)
        {
            // 两点巡逻
            currentPoint = currentPoint == 0 ? 1 : 0;
        }
    }
    private void SearchPlayer()
    {
        target = null;
        Collider[] colliders = Physics.OverlapSphere(transform.position, searchRadius);
        foreach (Collider collider in colliders)
        {
            if(collider.CompareTag(playerTag))
            {
                target = collider.transform;
                break;
            }
        }
    }

    void ResetSwitch()
    {
        isReadyToSwitch = true;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        // 绘制球形范围，选中敌人就能看到
        Gizmos.DrawWireSphere(transform.position, searchRadius);
    }

}