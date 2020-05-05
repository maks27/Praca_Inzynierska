using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class PlayerMovment : MonoBehaviour
{
    //Zmienne
    private bool running = false;
    public float speed;
    public float runspeed;
    float spin = 0f;
    Vector3 move = Vector3.zero;
    CharacterController controller;
    Animator anim;
    PlayerStats PlayerStats;
    public delegate void Stamina();
    public Stamina staminat;
    protected AnimatorOverrideController AnimatorOverrideController;
    public AnimationClip[] attackClip;
    static float speed2;
    void Start()
    {
        
        controller = GetComponent<CharacterController>();
        anim = GetComponentInChildren<Animator>();
        PlayerStats = GetComponent<PlayerStats>();
        staminat += UpdateUI;
        AnimatorOverrideController = new AnimatorOverrideController(anim.runtimeAnimatorController);
        anim.runtimeAnimatorController = AnimatorOverrideController;
        speed2 = speed;
    }
    void Update()
    {
        float z = Input.GetAxis("Vertical");
        if (controller.isGrounded)
        {
            if (Input.GetMouseButtonDown(0))
            {
                anim.SetBool("Attack", true);
                AnimationAttack();
               

            }
            if (Input.GetMouseButtonUp(0))
            {

                anim.SetBool("Attack", false);

            }

            if (Input.GetKey(KeyCode.W))
             anim.SetBool("Walking", true);
            else
            anim.SetBool("Walking", false);
            

            if (Input.GetKey(KeyCode.LeftShift))
            {
                speed = runspeed;
                anim.SetBool("Run", true);
                running = true;
            }
            else
            {
                running = false;
                speed = speed2;
                anim.SetBool("Run", false);
            }
            if (staminat != null) staminat.Invoke();
            move = transform.forward * z * speed;
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
            speed = speed2;
            anim.SetBool("Run", false);
        }else if(PlayerStats.Currentstamina >= PlayerStats.maxstamina)
        {
            PlayerStats.Currentstamina = PlayerStats.maxstamina;
        }
      
      
       
    }
      void AnimationAttack()
    {
        int aimindex = UnityEngine.Random.Range(0, attackClip.Length);
        AnimatorOverrideController["Armature|Atak01"] = attackClip[aimindex];

        
            
    }
}
