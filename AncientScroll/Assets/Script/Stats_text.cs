using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Stats_text : MonoBehaviour
{
    PlayerStats PlayerStats;
    public TextMeshProUGUI hptext;
    public TextMeshProUGUI sttext;
    public TextMeshProUGUI strtext;
    public TextMeshProUGUI charrtext;
    public TextMeshProUGUI armor;
    public TextMeshProUGUI damage;
    // Start is called before the first frame update
    void Start()
    {
        PlayerStats = PlayerStats.players;
    }

    // Update is called once per frame
    void Update()
    {
        hptext.text ="Punkty Życia : " + (PlayerStats.CurrentHealth.ToString() + " / " + PlayerStats.maxHealth.ToString());
        sttext.text = "Punkty Wytrzymałości : " + (PlayerStats.Currentstamina.ToString("0.") + " / " + PlayerStats.maxstamina.ToString());
        strtext.text = "Siła : " + PlayerStats.strenght.ToString();
        charrtext.text = "Charyzma : " + PlayerStats.charism.ToString();
        armor.text = "Punkty zbroi : " + PlayerStats.armor.GetValue().ToString();
        damage.text = "Obrażenia : " + PlayerStats.damage.GetValue().ToString();
    }
}
