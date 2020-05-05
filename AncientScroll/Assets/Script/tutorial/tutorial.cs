using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class tutorial : MonoBehaviour
{
    TextMeshProUGUI text;
    TextMeshProUGUI text2;
    public GameObject tutorialtext;
    public GameObject sword;
    public GameObject potion;
    public GameObject invtext;
    public GameObject player;
    Inventory Inventory;
    IPickup pickup;
    IPickup pickup2;
    EquipmentManage manage;
    public GameObject manager;
    bool check =true;
    bool check2 = false;
    bool check3 = false;
    bool check4 =false;
    bool check5 = false;
    bool check6 = false;
    bool check7 = false;
    bool check8 = false;
    bool check9 = false;
   
    void Start()
    {
        text = tutorialtext.GetComponent<TextMeshProUGUI>();
        text.text = "witaj w grze Starożytny zwój wciśnij W aby się poruszyć";
        pickup = sword.GetComponent<IPickup>();
        pickup2 = potion.GetComponent<IPickup>();
        text2 = invtext.GetComponent<TextMeshProUGUI>();
        Inventory = player.GetComponent<Inventory>();
        manage = manager.GetComponent<EquipmentManage>();


    }

    // Update is called once per frame
    void Update()
    {
        if(check == true)
        {
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
            {
                text.text = "Teraz wciśnij klaiwsz D lub A aby obrócić postać.";
                check = false;
                check2 = true;
            }
        }
        if(check2 == true)
        {
            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A))
            {
                text.text = "Możesz równiez poruszać myszką w góre oraz w dół aby się rozglądać.";
                check2 = false;
                check3 = true;
            }
        }
        if(check3 == true)
        {
            if (Input.GetAxis("Mouse Y") == 1 || Input.GetAxis("Mouse Y") == -1)
            {
                text.text = "Dobrze teraz podejdz do szkieletu i weź swoja pierwsza broń oraz miksture leczenia poprzez wcisnięcie klawisza E.Służy on do wchodzenia w interakcję z przedmiotami lub postaciami.";
                check3 = false;
                check4 = true;
            }
        }
        if(check4 == true)
        {
            if(pickup.pick == true && pickup2.pick == true)
            {
                text.text = "Dobrze teraz otwórz ekwipunek wciskając kalwisz I";
                check4 = false;
                check5 = true;
            }
            
        }
        if(check5 == true)
        {
            if(Input.GetKey(KeyCode.I))
            {
                invtext.SetActive(true);
                text2.text = "W ekwipunku znajdują się posiadane przedmioty,statystyki bohatera oraz dziennik zadań.Słuzy on także do rozwijania cech bohatera ,gdy ten zdobędzie nowy poziom.Aby użyć dany przedmiot, kliknij na niego i zamknij ekwipunek wciskając klawisz I";
                check5 = false;
                check6 = true;
                tutorialtext.SetActive(false);


            }
        }
        if(check6 == true)
        {
            if (manage.check == true)
            {
                if (Inventory.enableInventory == false)
                {
                    tutorialtext.SetActive(true);
                    text.text = "Aby poruszać się szybciej wciśnij klawisz shift podczas ruchu bohatera";
                    check6 = false;
                    check7 = true;

                }
                
            }
            
        }
        if(check7 == true)
        {
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                text.text =  "Teraz wciśnij lewy przycisk myszki aby wykonać atak";
                check7 = false;
                check8 = true;
                invtext.SetActive(false);
            }
        }
        if (check8 == true)
        {
            if (Input.GetMouseButtonDown(0))
            {
            
                text.text = "Świetnie ostatnią rzeczą jest menu do którego możesz się dostać wciskając klawisz esc.Znajdziesz tam ustawienia głośności gry.Życzę miłej zabawy";
                check8 = false;
                check9 = true;
            }
        }
        if (check9 == true)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                Destroy(gameObject);
            }
        }

    }
}
