using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    public int maxHealth;
    public int CurrentHealth { get; set; }
    public Stats damage;
    public Stats armor;

     void Awake()
    {
        CurrentHealth = maxHealth;

    }
    public void  Damage(int damage)
    {
        damage -= armor.GetValue();
        damage = Mathf.Clamp(damage, 0, int.MaxValue);
        CurrentHealth -= damage;
        Debug.Log("you deal" + damage);
        if(CurrentHealth <=0)
        {
            Die();
        }

    }
    public virtual void Die()
    {

    }
}
