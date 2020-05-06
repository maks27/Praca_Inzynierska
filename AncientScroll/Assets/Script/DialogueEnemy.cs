using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogueEnemy : MonoBehaviour
{
    public Dialogue dialogue;
    public GameObject charismaoption;
    Button button;
    TextMeshProUGUI text;
    public string charisma;
    bool work = false;
    EnemyController controller;
    PlayerStats playerStats;
    public GameObject player;
    DialogeManager manager;
    public GameObject managerInstance;
    public GameObject Enemy1;
    public GameObject Enemy2;
    public GameObject Quest;
    BanditQuest BanditQuest;

    void Start()
    {
        manager = managerInstance.GetComponent<DialogeManager>();
        button = charismaoption.GetComponent<Button>();
        playerStats = player.GetComponent<PlayerStats>();
        text = charismaoption.GetComponent<TextMeshProUGUI>();
        controller = GetComponent<EnemyController>();
        charismaoption.SetActive(true);
        BanditQuest = Quest.GetComponent<BanditQuest>();
       
    }

    // Update is called once per frame
    void Update()
    {
        if (work == false)
        {
            manager.endcheck = false;
            if (controller.talk == true)
            {

                MakeDialoge();

            }

        }
        if (manager.endcheck == true)
        {
            charismaoption.SetActive(false);
            controller.iftalk = false;
            GetComponent<Enemy>().enabled = true;
            Enemy1.GetComponent<EnemyController>().wait = false;
            Enemy2.GetComponent<EnemyController>().wait = false;
        }

    }
    public void MakeDialoge()
    {
        GetComponent<Enemy>().enabled = false;
        FindObjectOfType<DialogeManager>().MakeDialogue(dialogue, work);
        if (playerStats.charism >= 14)
        {
            button.interactable = true;

        }
        text.text = charisma;
        work = true;
        

    }
    public void Charismadialouge()
    {
        FindObjectOfType<DialogeManager>().CharismaSpeech(dialogue);
        controller.enabled = false;
        charismaoption.SetActive(false);
        BanditQuest.talk = true;

    }

}
