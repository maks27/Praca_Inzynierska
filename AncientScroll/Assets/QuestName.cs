using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class QuestName : MonoBehaviour
{
    public GameObject Quest;
    BanditQuest BanditQuest;
    public GameObject Questlabel;
    TextMeshProUGUI text;


    private void Start()
    {
        BanditQuest = Quest.GetComponent<BanditQuest>();
        text = Questlabel.GetComponent<TextMeshProUGUI>();
    }
    public void Update()
    {
        text.text = BanditQuest.questname;
    }

}
