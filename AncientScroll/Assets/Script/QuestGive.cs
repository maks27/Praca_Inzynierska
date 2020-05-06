using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
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
            dialouge.check = true;
          
            
        }
    }
   
    public  void StartQuest()
    {

        ActiveQuest.SetActive(true);
    }

     
}
