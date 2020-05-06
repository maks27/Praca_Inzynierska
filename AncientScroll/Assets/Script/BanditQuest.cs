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
        Enemy.SetActive(true);


    }

    // Update is called once per frame
    void Update()
    {
      
        Enemy2.SetActive(true);
        Enemy3.SetActive(true);

            
        TextMesh.text = questname;
        if (enemyStats.isdie == true || talk == true)
        {
            Debug.Log("Quest zrobiony");
            end = true;
        }
    }
}
