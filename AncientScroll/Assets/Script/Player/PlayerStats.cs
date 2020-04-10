using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Timers;
using UnityEngine.SceneManagement;

public class PlayerStats : CharacterStats
{
    public static PlayerStats players;
    public Slider hpcount;
    public Slider staminacount;
    public float maxstamina = 200;
    public int strange;
    public int dexterity;
    public int inteligent;
    public int charism;
    public float Currentstamina { get; set; }
    // Start is called before the first frame update
    void Start()
    {
        EquipmentManage.Manage.onEquipinfo += OnEquipchange;
        maxHealth = 100;
        CurrentHealth = maxHealth;
        Currentstamina = maxstamina;
    }

    // Update is called once per frame
    void Update()
    {
        hpcount.value = CurrentHealth;
        staminacount.value = Currentstamina;
        hpcount.maxValue = maxHealth;
        staminacount.maxValue = maxstamina;

        
       
    }
    private void Awake()
    {
        players = this;
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
    public override void Die()
    {
        if (CurrentHealth <= 0)
        {
            base.Die();
            SceneManager.LoadScene(2);
        }
    }

}
