using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    //Zmienne
    public bool Jump = true;
    public bool Sneak;
    public float speed;
    public float runspeed;
    public float jump_speed;
    float spin = 0f;
    Vector3 move = Vector3.zero;
    CharacterController controller;
    Animator anim;
    Rigidbody rb;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        if (controller.isGrounded)
        {
            if (Input.GetKey(KeyCode.W))
            {
                anim.SetBool("Walking", true);
                move = new Vector3(0, 0, 1);
                move *= speed;
                move = transform.TransformDirection(move);
            }
            if(Input.GetKeyUp(KeyCode.W))
            {
               move = new Vector3(0,0,0);
                anim.SetBool("Walking", false);
            }
            if(Input.GetKeyDown(KeyCode.LeftShift))
            {
                speed *= runspeed;
                anim.SetBool("Run",true);
            }
            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                speed = 1;
                anim.SetBool("Run", false);

            }
            if (!false && Input.GetKeyUp(KeyCode.Space))
            { 
                   
                move = Vector3.zero;
                Jump = true;
               
            }
            if (Input.GetKeyDown(KeyCode.Space) && Jump)
            {
             
                    rb.AddForce(move = Vector3.up * jump_speed);
                Jump = false;
               
                    
                
            }

            spin += Input.GetAxis("Horizontal");
            transform.eulerAngles = new Vector3(0, spin, 0);

        }

        controller.Move(move * Time.deltaTime);
    }

}
