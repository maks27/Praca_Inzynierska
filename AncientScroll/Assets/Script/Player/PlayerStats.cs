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
    public int strenght;
    public int charism;
    public Button Strlevel;
    public Button Charismlevel;
    public int pointsperlevel;
    int temppoints;
    public int currentexp;
    public GameObject levelup;
    public delegate void changestrenght();
    public changestrenght Changestrenght;
    int strmodifaier;
    public float Currentstamina { get; set; }
    // Start is called before the first frame update
    void Start()
    {
        strmodifaier = strenght / 2;
        damage.AddMod(strmodifaier);
        EquipmentManage.Manage.onEquipinfo += OnEquipchange;
        maxHealth = 100;
        CurrentHealth = maxHealth;
        Currentstamina = maxstamina;
        Changestrenght += changestrenghtmod;
    }

    // Update is called once per frame
    void Update()
    {
        hpcount.value = CurrentHealth;
        staminacount.value = Currentstamina;
        hpcount.maxValue = maxHealth;
        staminacount.maxValue = maxstamina;
        if(currentexp >=100)
        {
            LevelUp();
            levelup.SetActive(true);
            currentexp = 0;
        }
         if(temppoints <= 0)
        {
            Strlevel.interactable = false;
            Charismlevel.interactable = false;
            levelup.SetActive(false);
        }
       
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
    public void LevelUp()
    {
        temppoints = pointsperlevel;
        Strlevel.interactable = true;
        Charismlevel.interactable = true;
        
    }
    public void addStr()
    {
        strenght += 1;
        temppoints -= 1;
        if (Changestrenght != null) Changestrenght.Invoke();
    }
    public void addCharism()
    {
        charism += 1;
        temppoints -= 1;
    }
    public void Heal(int hpheal)
    {
        Mathf.Clamp(CurrentHealth, 0, 100);
        if(CurrentHealth < maxHealth)
        {
            CurrentHealth += hpheal;
        }
    }
    public void changestrenghtmod()
    {
        damage.AddMod(strmodifaier);
    }

}
