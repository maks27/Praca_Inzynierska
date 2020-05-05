using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestGive : Interactive
{
    InteractionDialouge dialouge;
    public GameObject ActiveQuest;
    BanditQuest BanditQuest;
    public string endQuestline;
    public GameObject Npc;
    private void Start()
    {
        dialouge = Npc.GetComponent<InteractionDialouge>();
        BanditQuest = ActiveQuest.GetComponent<BanditQuest>();
        
    }
    private void Update()
    {
        if(dialouge.EndDialouge==true)
        {
            StartQuest();
        }
        if(BanditQuest.end == true)
        {
            dialouge.dialogue.endline = endQuestline;
        }
    }
   
    public  void StartQuest()
    {

        ActiveQuest.SetActive(true);
    }
     
}
