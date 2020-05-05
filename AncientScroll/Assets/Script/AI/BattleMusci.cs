using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleMusci : MonoBehaviour
{
    AudioSource audioSource;
    public float radious = 10f;
    public GameObject panel;
    EnemyStats enemy;
    Transform target;
    public GameObject enemyinst;
    // Start is called before the first frame update
    void Start()
    {
        target = PlayerManager.instance.player.transform;
        audioSource = panel.GetComponent<AudioSource>();
        enemy = enemyinst.GetComponent<EnemyStats>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);
        if (distance <= radious)
        {
            audioSource.enabled = false;
            
           
            
        }
        else
        {
            audioSource.enabled = true;
        }
        if(enemy.isdie)
        {
            audioSource.enabled = true;
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radious);
    }
}
