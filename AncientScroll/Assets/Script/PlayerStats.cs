using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Timers;

public class PlayerStats : MonoBehaviour
{
    public static PlayerStats players;
    public float hp = 1000;
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

    }

    // Update is called once per frame
    void Update()
    {


        hpcount.value = hp;
        staminacount.value = stamina;

        if (hp <= 0)
        {
            Debug.Log("Gameover");
        }
        
       
    }
    private void Awake()
    {
        players = this;
    }
    public void Damage(int damage)
    {
      
        hp -= damage;
        Debug.Log(hp);
    }
    public void heal(int damage)
    {

        hp += damage;
        Debug.Log(hp);
    }
    public void Staminareg(int value)
    {
        stamina += value;
    }


}
