using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestGive : MonoBehaviour
{
    InteractionDialouge dialouge;
    public GameObject ActiveQuest;
    BanditQuest BanditQuest;
    private void Start()
    {
        dialouge = GetComponent<InteractionDialouge>();
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
            FindObjectOfType<DialogeManager>().CharismaSpeech(dialouge.dialogue.charismaresponse);
        }
    }
    public  void StartQuest()
    {

        ActiveQuest.SetActive(true);
    }
     
}
