using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Timers;

public class PlayerMovment : MonoBehaviour
{
    //Zmienne
    public bool Jump = false;
    public bool Sneak;
    private bool running = false;
    public float speed;
    public float runspeed;
    public float jump_speed;
    float spin = 0f;
    Vector3 move = Vector3.zero;
    CharacterController controller;
    Animator anim;
    Rigidbody rb;
    PlayerStats PlayerStats;
    public delegate void Stamina();
    public Stamina staminat;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody>();
        PlayerStats = GetComponent<PlayerStats>();
        staminat += UpdateUI;
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
            if (Input.GetKeyUp(KeyCode.W))
            {
                move = new Vector3(0, 0, 0);
                anim.SetBool("Walking", false);
            }
            
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                
                speed *= runspeed;
                anim.SetBool("Run", true);
                running = true;
            }
            
        
            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                running = false;
                speed = 1;
                anim.SetBool("Run", false);
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rb.AddForce(move = Vector3.up * jump_speed, ForceMode.Impulse);
               
            }
            
          


            if (staminat != null) staminat.Invoke();
            spin += Input.GetAxis("Horizontal");
            transform.eulerAngles = new Vector3(0, spin, 0);


        }

        controller.Move(move * Time.deltaTime);
    }
  
    
        public void UpdateUI()
    {
        if (running)
        {
            PlayerStats.Currentstamina -= Time.deltaTime *20;
        }
        if (running == false)
        {
            PlayerStats.Currentstamina += Time.deltaTime*10;

        }
        if (PlayerStats.Currentstamina <= 0)
        {
            PlayerStats.Currentstamina = 0;
            speed = 1;
            anim.SetBool("Run", false);
        }else if(PlayerStats.Currentstamina >= PlayerStats.maxstamina)
        {
            PlayerStats.Currentstamina = PlayerStats.maxstamina;
        }
        if(Jump)
        {
            move = new Vector3(0, 1, 1);
            Jump = false;
        }
      
       
    }
   
}
