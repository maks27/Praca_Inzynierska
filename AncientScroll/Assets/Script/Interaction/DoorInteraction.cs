using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorInteraction : Interactive
{
    Animator animation;
    BoxCollider collider;
    private void Start()
    {
        animation = GetComponent<Animator>();
        collider = GetComponent<BoxCollider>();
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
            animation.SetBool("IsOpen", true);
            collider.isTrigger = true;

            if (animation.GetCurrentAnimatorStateInfo(0).IsName("DoorOpenState"))
            {
                animation.SetBool("IsOpen", false);
                collider.isTrigger = false;
            }
           
        }
    }
    
 


}
