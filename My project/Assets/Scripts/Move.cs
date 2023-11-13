using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float mouseSensitivity = 1000.0f; // Czułość myszy
    private float rotationX = 0f;

    public Transform cameraBody;

    void Update()
    {
        // Odczytaj ruch myszy
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // Obrót kamery w poziomie (w prawo i w lewo)
        rotationX -= mouseY; // Zmiana znaku dla obrotu w prawo i w lewo
        rotationX = Mathf.Clamp(rotationX, -90f, 90f); // Ograniczenie kąta obrotu

        // Przypisanie obrotu do kamery
        transform.localRotation = Quaternion.Euler(rotationX, 0f, 0f);

        cameraBody.Rotate(Vector3.up * mouseX);

        // Poruszanie postacią
        // float horizontalMovement = Input.GetAxis("Horizontal");
        // float verticalMovement = Input.GetAxis("Vertical");

        // Vector3 movement = new Vector3(horizontalMovement, 0, verticalMovement);
        // movement = transform.TransformDirection(movement);
    }
}
