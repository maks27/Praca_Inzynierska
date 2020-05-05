using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName ="New item",menuName ="Inventory/Item")]
public class Item : ScriptableObject
{
    
    new public string name = "New item";
    public Sprite icon = null;
    public bool isDefItem = false;

    public virtual void Use ()
    {
        Debug.Log("Use Item");
    }
    public void RemovefromInv()
    {
        Inventory.Inv.Remove_it(this);
    }

}
