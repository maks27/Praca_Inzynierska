using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipmentSlot : MonoBehaviour
{
    Equip equip;
    public Image icon;
    // public Button removeB;
 
    public void AddEq(Equip newequip)
    {
        equip = newequip;
        icon.enabled = true;
        icon.sprite = equip.icon;
        
        
    }
    
}
