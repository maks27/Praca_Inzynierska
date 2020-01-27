using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stats_text : MonoBehaviour
{
    PlayerStats PlayerStats;
    public Text hptext;
    public Text sttext;
    public Text strtext;
    public Text dextext;
    public Text inttext;
    public Text charrtext;
    public Text armor;
    public Text damage;
    // Start is called before the first frame update
    void Start()
    {
        PlayerStats = PlayerStats.players;
    }

    // Update is called once per frame
    void Update()
    {
        hptext.text =(PlayerStats.CurrentHealth.ToString() + " / " + PlayerStats.maxHealth.ToString());
        sttext.text = (PlayerStats.Currentstamina.ToString("0.") + " / " + PlayerStats.maxstamina.ToString());
        strtext.text = PlayerStats.strange.ToString();
        dextext.text = PlayerStats.dexterity.ToString();
        inttext.text = PlayerStats.inteligent.ToString();
        charrtext.text = PlayerStats.charism.ToString();
        armor.text = PlayerStats.armor.GetValue().ToString();
        damage.text = PlayerStats.damage.GetValue().ToString();
    }
}
