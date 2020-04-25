using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMenager : MonoBehaviour
{
    public static CameraMenager instance;

    private void Awake()
    {
        instance = this;
    }

    public Camera cam;
}
