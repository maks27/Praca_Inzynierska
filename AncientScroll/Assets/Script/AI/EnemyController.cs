using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
public class EnemyController : MonoBehaviour
{
    public float radious = 10f;
    Transform target;
    NavMeshAgent agent;
    PlayerStats playerStats;
    Combat combat;
    Animator animator;
    public GameObject HealtBar;
    public GameObject Bar;
    public bool iftalk = false;
    public bool talk { get; private set; } = false;
    EnemyStats enemyStats;
    Image health;
    public int speed;
    public int sprint;
    public bool wait;
    void Start()
    {
        enemyStats = GetComponent<EnemyStats>();
        agent = GetComponent<NavMeshAgent>();
        target = PlayerManager.instance.player.transform;
        playerStats = PlayerStats.players;
        combat = GetComponent<Combat>();
        animator = GetComponentInChildren<Animator>();
        health = Bar.GetComponentInChildren<Image>();
        
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("Walk", false);
        float distance = Vector3.Distance(target.position, transform.position);
        if(wait == false)
        {
            if (distance <= radious)
            {
                animator.SetBool("Walk", true);
                if (distance <= radious / 2)
                {

                    animator.SetBool("Sprint", true);
                    agent.speed = sprint;

                }
                else
                {
                    animator.SetBool("Sprint", false);
                    agent.speed = speed;
                }
                agent.SetDestination(target.position);
                if (distance <= agent.stoppingDistance)
                {
                    HealtBar.SetActive(true);
                    animator.SetBool("Walk", false);
                    animator.SetBool("Sprint", false);
                    if (iftalk == true) talk = true;
                    if (iftalk == false)
                    {

                        HealthBars();
                        CharacterStats tStats = target.GetComponent<CharacterStats>();
                        if (tStats != null)
                        {
                            animator.SetTrigger("Attack");
                            combat.Attack(tStats);
                        }
                    }
                    FaceTarget();
                }

            }

        }
        if(wait ==true)
        {
            HealtBar.SetActive(false);
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
    void HealthBars()
    {
        if (enemyStats.isdie == false)
        {
            float hp;
            float curent;
            hp = enemyStats.maxHealth;
            curent = enemyStats.CurrentHealth / hp;
            health.fillAmount = curent;
        }

        


    }
}
