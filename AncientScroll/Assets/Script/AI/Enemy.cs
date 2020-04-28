using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterStats))]
public class Enemy : Interactive
{
    PlayerManager playerManager;
    CharacterStats mStats;
   
    
    private void Start()
    {
        playerManager = PlayerManager.instance;
        mStats = GetComponent<CharacterStats>();
    }

    public override void Interact()
    {
        base.Interact();
        if (Input.GetMouseButton(0)) 
        {


            Combat playerCombat = playerManager.player.GetComponent<Combat>();
            if (playerCombat != null)
            {
                playerCombat.Attack(mStats);
            }
        }
    }

}
