using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionDialouge : Interactive
{
    public Dialogue dialogue;
    public bool EndDialouge = false;


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
        

    }

    
}
