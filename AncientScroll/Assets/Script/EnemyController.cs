using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyController : MonoBehaviour
{
    public float radious = 10f;
    Transform target;
    NavMeshAgent agent;
    PlayerStats playerStats;
    Combat combat;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        target = PlayerManager.instance.player.transform;
        playerStats = PlayerStats.players;
        combat = GetComponent<Combat>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);

        if(distance <= radious)
        {
            agent.SetDestination(target.position);
            if (distance <= agent.stoppingDistance)
            {
                CharacterStats tStats = target.GetComponent<CharacterStats>();
                if (tStats != null)
                {
                    combat.Attack(tStats);
                }
                FaceTarget();
            }
        }
    }
    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookrotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookrotation, Time.deltaTime * 5f);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position,radious);
    }
}
