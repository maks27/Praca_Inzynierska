using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvUI : MonoBehaviour
{
    public Transform Slots;
    Inventory inventory;
    InvSlot[] slot;
    void Start()
    {
        inventory = Inventory.Inv;
        inventory.onItemChangeinfo += UpdateUI;
        slot = Slots.GetComponentsInChildren<InvSlot>();
    }

    // Update is called once per frame
    void Update()
    {
      
    }
    void UpdateUI()
    {
        for (int i = 0; i < slot.Length; i++)
        {
            if (i < inventory.items.Count)
            {
                slot[i].Add(inventory.items[i]);
            }
            else
            {
                slot[i].Clear();
            }
        }
    }
}
