using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InvSlot : MonoBehaviour
{
    Item item;
    public Image icon;
    public Button removeB;
    public void Add (Item newItem)
    {
        item = newItem;
        icon.sprite = item.icon;
        icon.enabled = true;
        removeB.interactable = true;
        
    }
    public void Clear()
    {
        item = null;
        icon.sprite = null;
        icon.enabled = false;
        removeB.interactable = false;
    }
    public void OnRemoveButton ()
    {
        Inventory.Inv.Remove_it(item);
    }
    public void UseI()
    {
        if(item != null)
        {
            item.Use();
            
        }
    }

}
