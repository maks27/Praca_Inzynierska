using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    // Start is called before the first frame update
    public float mSpeed = 10f;
    public Transform player;
    float xRotation = 0f;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mX = Input.GetAxis("Mouse X") * mSpeed * Time.deltaTime;
        float mY = Input.GetAxis("Mouse Y") * mSpeed * Time.deltaTime;
        xRotation -= mY;
        xRotation = Mathf.Clamp(xRotation,-100f,100f);
        player.Rotate(Vector3.up * mX);
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

    }
}
