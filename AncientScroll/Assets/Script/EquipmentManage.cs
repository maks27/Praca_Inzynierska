using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EquipmentManage : MonoBehaviour
{
    public Transform Slots;
    public static EquipmentManage Manage;
    Inventory Inventory;
    EquipmentSlot[] SlotsEq;
    public delegate void Equipdelegat(Equip newitem, Equip oldItem);
    public Equipdelegat onEquipinfo;
    EquipmentSlot EquipmentSlot;
    public delegate void VisualEquip();
    public VisualEquip visualinfo;
    private void Awake()
    {
        Manage = this;
    }
    Equip[] EquipNow;

    private void Start()
    {
        int numSlots = System.Enum.GetNames(typeof(EquipSlot)).Length;
        EquipNow = new Equip[numSlots];
        Inventory = Inventory.Inv;
        SlotsEq = Slots.GetComponentsInChildren<EquipmentSlot>();
        visualinfo += UpdateUI;
    }
    public void Equipthis(Equip equip)
    {
        int slotI = (int)equip.Cathegories;
        Equip old = null;
        if (EquipNow[slotI] != null)
        {
            old = EquipNow[slotI];
            Inventory.Add_it(old);
        }
        EquipNow[slotI] = equip;
        if (onEquipinfo != null) onEquipinfo.Invoke(equip,old);
        if (visualinfo != null) visualinfo.Invoke();

    }
    public void UpdateUI()

    {
        for (int i = 0; i < 9; i++)
        {
            if (EquipNow[i] != null)
            {
                SlotsEq[i].AddEq(EquipNow[i]);


            }
        }
        
    }
 






}
