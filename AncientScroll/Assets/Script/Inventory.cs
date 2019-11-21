using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Inventory : MonoBehaviour
{
    public bool enableInventory;
    public GameObject inventory;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
            enableInventory =!enableInventory;
        if(enableInventory ==true)
        {
            inventory.SetActive(true);
        }
        else
        {
            inventory.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadSceneAsync(0);

        }

        
    }
}
