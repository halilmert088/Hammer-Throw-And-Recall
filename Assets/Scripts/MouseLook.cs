using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float sensitivity = 100f;

    public Transform playerBody;
    public Transform hammer;

    float xRotation = 0f;

    public float XRotation { get => xRotation; set => xRotation = value; }

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

        XRotation -= mouseY; // inverted olmasýn diye -= koyduk
        XRotation = Mathf.Clamp(XRotation, -90f, 90f);
        
        transform.localRotation = Quaternion.Euler(XRotation, 0f, 0f); // Quaternion.Euler (x, y, z)
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
