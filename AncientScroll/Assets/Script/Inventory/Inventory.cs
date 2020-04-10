using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Inventory : MonoBehaviour
{
    public bool enableInventory;
    public GameObject inventory;
    public List<Item> items = new List<Item>();
    public static Inventory Inv;
    public int space = 20;
    public bool check = false;
    public delegate void ChangedItem();
    public ChangedItem onItemChangeinfo;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
            enableInventory =!enableInventory;
        if(enableInventory ==true)
        {
            inventory.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            inventory.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadSceneAsync(0);

        }
      
    }
    private void Awake()
    {
        if (Inv != null)
        {
            Debug.LogWarning("Blaad");
            return;
          }      
        Inv = this;
    }
    public void Add_it(Item item)
    {

        if (item.isDefItem == false)
        {
            if (items.Count >= space)
            {
                Debug.Log("Nie dodano obiektu");
                return;
            }
            check = true;
            items.Add(item);
            if (onItemChangeinfo != null) onItemChangeinfo.Invoke();



        }
        
    }
            
    
    public void Remove_it(Item item)
    {
        items.Remove(item);
        if (onItemChangeinfo != null) onItemChangeinfo.Invoke();
    }
}
