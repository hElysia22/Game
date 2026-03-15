using UnityEngine;
using UnityEngine.AI;

public class EnemyNav : MonoBehaviour
{
    private Transform target;
    private NavMeshAgent agent;
    public float searchRadius = 50f;
    private string playerTag = "Player";
    public float updateInterval = 0.3f;
    private float timer = 0;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer > updateInterval)
        {
            SearchPlayer();
            timer = 0;
            if(target != null)
            {
                if(Vector3.Distance(transform.position, target.position) > agent.stoppingDistance)
                {
                    agent.SetDestination(target.position);
                }
                else
                {
                    agent.ResetPath();
                }
            }
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

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        // 绘制球形范围，选中敌人就能看到
        Gizmos.DrawWireSphere(transform.position, searchRadius);
    }

}