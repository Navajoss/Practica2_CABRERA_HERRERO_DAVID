using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPS_Camera : MonoBehaviour
{
    public float Sensivility = 200;
    public Transform playerBody;
    public float xRotacion;
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * Sensivility * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * Sensivility * Time.deltaTime;

        xRotacion -= mouseY;
        xRotacion = Mathf.Clamp(xRotacion, -89, 89);

        transform.localRotation = Quaternion.Euler(xRotacion, 0, 0);

        playerBody.Rotate(Vector3.up * mouseX);
    }
}
