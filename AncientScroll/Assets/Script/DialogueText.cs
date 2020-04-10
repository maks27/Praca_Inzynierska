using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class DialogueText : MonoBehaviour
{

    public TextMeshProUGUI display;
    public Button button;
    public void AddText(string text)
    {
        display.text = text;
     

    }

}
