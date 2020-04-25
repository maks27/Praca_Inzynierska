using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementManager : MonoBehaviour
{
    public static MovementManager movement;
    private void Awake()
    {
        movement = this;
    }
    public GameObject player;
}
