using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Equipment", menuName = "Inventory/Potion")]
public class HelathPotionItem : Item
{
    public int hpheal;
    public override void Use()
    {
        base.Use();
        if(PlayerStats.players.CurrentHealth < PlayerStats.players.maxHealth)
        {
            PlayerStats.players.Heal(hpheal);
            Inventory.Inv.Remove_it(this);
        }
    

    }
}
