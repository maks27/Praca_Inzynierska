using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BanditQuest : MonoBehaviour
{
    public GameObject Enemy3;
    public GameObject Enemy2;
    public GameObject Enemy;
    EnemyStats enemyStats;
    public string questname { get; private set; } = "";
    public string questnext { get; private set; } = "";
    TextMeshProUGUI TextMesh;
    public GameObject questlabel;
    bool enableQuest;
    public bool talk = false;
    public bool end { get; private set; } = false;
    void Start()
    {
        TextMesh = questlabel.GetComponent<TextMeshProUGUI>();
        enemyStats = Enemy.GetComponent<EnemyStats>();
        questname = "Pomóż wioscę z odparciem najeźdzców";
        questnext = "Wróć do wójta wioski i zdaj mu relację";
        Enemy.SetActive(true);
        Enemy2.SetActive(true);
        Enemy3.SetActive(true);

    }

    // Update is called once per frame
    void Update()
    {
      
            
        TextMesh.text = questname;
        if (enemyStats.isdie == true || talk == true)
        {
            TextMesh.text = questnext;
            Debug.Log("Quest zrobiony");
            end = true;
        }
    }
}
