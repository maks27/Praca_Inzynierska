using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMAin : MonoBehaviour
{


    public GameObject player;
    public float cameraDistance = 0;
    public Camera cam;
    float zoom;
    public int speed;
    //Vector3 pos = 
    // Use this for initialization
    void Start()
    {
         
    }

    void LateUpdate()
    {
        transform.position = player.transform.position - player.transform.forward * cameraDistance;
        transform.LookAt(player.transform.position);
        transform.position = new Vector3(transform.position.x, transform.position.y + 2, transform.position.z);
        zoom = cam.fieldOfView;
        zoom -= Input.GetAxis("Mouse ScrollWheel") * speed;
        cam.fieldOfView = zoom;
    }
}