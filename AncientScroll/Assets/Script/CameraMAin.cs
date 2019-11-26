using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMAin : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    private Vector3 offset = new Vector3(0,0,-6);
    // Update is called once per frame
    public float rotationSpeed = 1 ;
    void Update()
    {
        Vector3 rotation = transform.eulerAngles;
        rotation.y += Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime;
        //transform.eulerAngles = player.transform.eulerAngles * rotationSpeed; 
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 3, player.transform.position.z) + offset;
        transform.eulerAngles = rotation;


    }
}
