using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorInteraction : Interactive
{
    Animator anim;
    BoxCollider coll;
    private void Start()
    {
        anim = GetComponent<Animator>();
        coll = GetComponent<BoxCollider>();
    }
    public override void Interact()
    {
        base.Interact();
        DoorAnim();

    }
    void DoorAnim()
    {
        Debug.Log("Open the door");

        if (Input.GetKey(KeyCode.E))
        {
            anim.SetBool("IsOpen", true);
            coll.isTrigger = true;

            if (anim.GetCurrentAnimatorStateInfo(0).IsName("DoorOpenState"))
            {
                anim.SetBool("IsOpen", false);
                coll.isTrigger = false;
            }
           
        }
    }
    
 


}
