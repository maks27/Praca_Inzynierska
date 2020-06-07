using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class QualityLevel : MonoBehaviour
{
   
    public void Low()
    {
        QualitySettings.SetQualityLevel(0);

    }
    public void Medium()
    {
        QualitySettings.SetQualityLevel(1);

    }
    public void High()
    {
        QualitySettings.SetQualityLevel(2);

    }
    public void Ultra()
    {
        QualitySettings.SetQualityLevel(3);

    }



}
