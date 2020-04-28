using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : CharacterStats
{
    // Start is called before the first frame update
    public bool isdie = false;
    public GameObject hp;
    public override void Die()
    {
        base.Die();
        isdie = true;
        hp.SetActive(false);
        Destroy(gameObject);
        

    }
}
