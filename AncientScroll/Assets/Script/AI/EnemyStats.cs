using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : CharacterStats
{
    // Start is called before the first frame update
    AudioSource audioSource;
    public GameObject panel;
    public bool isdie = false;
    public GameObject hp;
    PlayerStats playerStats;
    public int numberexp;
    public GameObject player;
    private void Start()
    {
        audioSource = panel.GetComponent<AudioSource>();
        playerStats = player.GetComponent<PlayerStats>();
    }
    public override void Die()
    {
        playerStats.currentexp += numberexp;
        base.Die();
        isdie = true;
        hp.SetActive(false);
        Destroy(gameObject);
        audioSource.enabled = true;

    }
}
