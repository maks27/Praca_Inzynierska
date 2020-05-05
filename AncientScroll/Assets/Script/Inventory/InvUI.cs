using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InvUI : MonoBehaviour
{
    public GameObject Panel;
    public Transform Slots;
    Inventory inventory;
    InvSlot[] slot;
    public GameObject jurnal;
    public TextMeshProUGUI text;
    public bool Change { get; private set; } = false;
    void Start()
    {
        inventory = Inventory.Inv;
        inventory.onItemChangeinfo += UpdateUI;
        slot = Slots.GetComponentsInChildren<InvSlot>();
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
    public void OpenJurnal()
    {
        Change = !Change;
        if(Change==true)
        {
            Panel.SetActive(false);
            jurnal.SetActive(true);
            text.text = "Ekwipunek";
        }
        else
        {
            Panel.SetActive(true);
            jurnal.SetActive(false);
            text.text = "Dziennik";
        }

    }
}
