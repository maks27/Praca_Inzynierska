using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionDialouge : Interactive
{
    public Dialogue dialogue;
    public bool EndDialouge = false;
    DialogeManager manager;
    public GameObject managerInstance;
    QuestGive banditQuest;
    public bool check = false;
    private void Start()
    {
        manager = managerInstance.GetComponent<DialogeManager>();
        banditQuest = GetComponent<QuestGive>();
    }
    public override void Interact()
    {
        base.Interact();
        if (Input.GetKeyDown(KeyCode.E))
        {
            Conversation();
            EndDialouge = true;

        }
    }
    void Conversation()
    {

        FindObjectOfType<DialogeManager>().MakeDialogue(dialogue,EndDialouge);
        if(check == true)
        {
            FindObjectOfType<DialogeManager>().EndQuestLine(banditQuest.endQuestline);
        }



    }


    
}
