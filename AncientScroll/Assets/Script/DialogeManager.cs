﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;



public class DialogeManager : MonoBehaviour
{
    MovementManager player;
    public Transform Texttransform;
    CameraMenager camMenager;
    public GameObject DialogueBox;
    public Dialogue dialogue;
    bool enableDialogueBox = false;
    DialogueText[] Dt;
    public Button button;
    Queue<string> npcconversation;
    Queue<string> playerresponse;
    public delegate void Enddialoge();
    public Enddialoge enddialoge;
    void Start()
    {
        player = MovementManager.movement;
        camMenager = CameraMenager.instance;
        npcconversation = new Queue<string>();
        playerresponse = new Queue<string>();
        Dt = Texttransform.GetComponentsInChildren<DialogueText>();
    }


    public void MakeDialogue(Dialogue dialogue,bool end)
    {

            Cursor.lockState = CursorLockMode.None;
            enableDialogueBox = true;
            npcconversation.Clear();
            playerresponse.Clear();
            camMenager.GetComponent<MouseLook>().enabled = false;
            player.GetComponent<PlayerMovment>().enabled = false;
        if (end == false)
        {
            foreach (string text in dialogue.npcconversation)
            {

                npcconversation.Enqueue(text);

            }
            foreach (string text in dialogue.playerresponse)
            {

                playerresponse.Enqueue(text);

            }
            OnCLick();
        }
            //OpenDialog();
            if (enableDialogueBox == true)
            {
                DialogueBox.SetActive(true);
            }
    
        
        if(end == true)
        {
            Dt[0].AddText(dialogue.endline);
            Dt[1].AddText("Koniec");
            
        }
    }
    public void OnCLick()
    {
        DisplayDialogue(npcconversation, playerresponse);
    }
    public void DisplayDialogue(Queue<string>queue,Queue<string>queue2)
    {

        if (queue.Count == 0)
        {
            Debug.Log("Koniec Dialogu");
            EndConv();
            return;
        }
        Dt[0].AddText(queue.Dequeue());
        Dt[1].AddText(queue2.Dequeue());
        

    }
    public void EndConv()
    {
        enableDialogueBox = false;
        if (enableDialogueBox == false)
        {
            DialogueBox.SetActive(false);
        }
        camMenager.GetComponent<MouseLook>().enabled = true;
        player.GetComponent<PlayerMovment>().enabled = true;
    }


}