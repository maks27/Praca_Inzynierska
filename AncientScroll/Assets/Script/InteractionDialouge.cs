using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionDialouge : Interactive
{

    public Dialogue dialogue;
   



    public override void Interact()
    {
        base.Interact();
        if (Input.GetKeyDown(KeyCode.E))
            Conversation();
    }
    void Conversation()
    {

        FindObjectOfType<DialogeManager>().MakeDialogue(dialogue);


    }
    
}
