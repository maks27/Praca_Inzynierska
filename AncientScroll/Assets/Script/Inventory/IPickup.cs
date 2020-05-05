using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IPickup : Interactive
{
    public Item Item;
    [HideInInspector]
    public bool pick = false;
    public override void Interact()
    {
        base.Interact();
        PickUp();
    }
    void PickUp()
    {
       
        if(Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Pick item" + Item.name);
            Inventory.Inv.Add_it(Item);
            if (Inventory.Inv.check)
            {
                Destroy(gameObject);
                Inventory.Inv.check = false;
                pick = true;
            }
        }
       
    }
}
