using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Inventory : MonoBehaviour
{
    public bool enableMenu;
    public bool enableInventory;
    public GameObject inventory;
    public GameObject Menu;
    public List<Item> items = new List<Item>();
    public static Inventory Inv;
    public int space = 20;
    public bool check = false;
    public delegate void ChangedItem();
    public ChangedItem onItemChangeinfo;
    MouseLook mouseLook;
    public Camera cam;


    private void Start()
    {
        mouseLook = cam.GetComponent<MouseLook>();
    }
    void Update()
    {
        if(Menu.activeSelf)
        {
            inventory.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.Escape))
            enableMenu = !enableMenu;
        if (Input.GetKeyDown(KeyCode.I))
            enableInventory = !enableInventory;
        if (enableMenu == true)
        {
            inventory.SetActive(false);
            Menu.SetActive(true);
            mouseLook.checkcursor = false;
            PauseGame();
        }
        if (enableMenu== false)
        {
            mouseLook.checkcursor = true;
            Menu.SetActive(false);
            ContinueGame();
        }
        if(enableInventory ==true)
        {
            inventory.SetActive(true);
            mouseLook.checkcursor = false;
            PauseGame();
        }
        if(enableInventory == false)
        {
            mouseLook.checkcursor = true;
            inventory.SetActive(false);
            ContinueGame();
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
    private void PauseGame()
    {
        Time.timeScale = 0;
    }
    private void ContinueGame()
    {
        Time.timeScale = 1;
    }
}
