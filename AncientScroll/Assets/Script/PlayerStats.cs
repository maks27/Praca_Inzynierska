using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Timers;

public class PlayerStats : CharacterStats
{
    public static PlayerStats players;
    public Slider hpcount;
    public Slider staminacount;
    public float stamina;
    public int strange;
    public int dexterity;
    public int inteligent;
    public int charism;
    
    // Start is called before the first frame update
    void Start()
    {
        EquipmentManage.Manage.onEquipinfo += OnEquipchange;
        maxHealth = 100;
        CurrentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        hpcount.value = CurrentHealth;
        staminacount.value = stamina;
        hpcount.maxValue = maxHealth;

        if (CurrentHealth <= 0)
        {
            Debug.Log("Gameover");
        }
        
       
    }
    private void Awake()
    {
        players = this;
    }

    public void Staminareg(int value)
    {
        stamina += value;
    }
    void OnEquipchange(Equip newItem,Equip olditem)
    {
        if (newItem != null)
        {
            armor.AddMod(newItem.armorm);
            damage.AddMod(newItem.damagem);
        }
        if(olditem != null)
        {
            armor.RemoveMod(olditem.armorm);
            damage.RemoveMod(olditem.damagem);
        }
    }

}
