using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;



public class DialogeManager : MonoBehaviour
{
    public Transform Texttransform;

    public GameObject DialogueBox;
    public Dialogue dialogue;
    bool enableDialogueBox = false;
    DialogueText[] Dt;
    public Button button;
    Queue<string> npcconversation;
    Queue<string> playerresponse;

    void Start()
    {
        npcconversation = new Queue<string>();
        playerresponse = new Queue<string>();
        Dt = Texttransform.GetComponentsInChildren<DialogueText>();
    }

    public void MakeDialogue(Dialogue dialogue)
    {
        enableDialogueBox = true;
        npcconversation.Clear();
        playerresponse.Clear();
        foreach (string text in dialogue.npcconversation)
        {

            npcconversation.Enqueue(text);

        }
        foreach (string text in dialogue.playerresponse)
        {

            playerresponse.Enqueue(text);

        }
        //OpenDialog();
        if (enableDialogueBox == true)
        {
            DialogueBox.SetActive(true);
        }
        OnCLick();
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
        return;
    }
    



}
