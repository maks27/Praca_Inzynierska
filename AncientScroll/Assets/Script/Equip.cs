using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName ="Equipment",menuName ="Inventory/Equip")]
public class Equip : Item
{
    public EquipSlot Cathegories;
    public int armorm;
    public int damagem;
    public override void Use()
    {
       
        base.Use();
        EquipmentManage.Manage.Equipthis(this);
        Inventory.Inv.Remove_it(this);
    }

}

public enum EquipSlot {Head,Chest,Legs,Arms,Necles,Ring,Weapon,Shield,Feet}