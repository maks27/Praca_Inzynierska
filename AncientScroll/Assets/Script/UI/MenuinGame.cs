using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MenuinGame : MonoBehaviour
{
    MouseLook mouseLook;
    public Camera cam;
    Inventory inventory;
    public GameObject player;
    public GameObject option;
    Slider Slider;





    void Start()
    {
        mouseLook = cam.GetComponent<MouseLook>();
        inventory = player.GetComponent<Inventory>();
        Slider = option.GetComponent<Slider>();
        

    }

    // Update is called once per frame
    void Update()
    {
        mouseLook.checkcursor = false;
        
    }
    public void NewGame()
    {
        SceneManager.LoadScene(1);
    }
    public void Kontynuuj()
    {
        inventory.enableMenu = false;
    }
   
    public void AdjustVolume()
    {
        
       AudioListener.volume = Slider.value;
    }
    public void EndAplication()
    {
        Application.Quit();
    }
}
