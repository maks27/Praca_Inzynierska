using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public float hp ;
    public Slider hpcount;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (hp <= 0)
        {
            Debug.Log("Gameover");
        }
        hpcount.value = hp;
       
    }
    public void Damage(int damage)
    {
      
        hp -= damage;
        Debug.Log(hp);
    }
   
    
}
