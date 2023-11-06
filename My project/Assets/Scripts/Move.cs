using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float mouseSensitivity = 2.0f; // Czułość myszy
    public float moveSpeed = 5.0f; // Prędkość poruszania się kamery
    public float mapSize = 30f; 
    private float rotationX = 0;

    void Update()
    {
        // Odczytaj ruch myszy
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        // Obrót kamery w poziomie (w prawo i w lewo)
        rotationX -= mouseY; // Zmiana znaku dla obrotu w prawo i w lewo
        rotationX = Mathf.Clamp(rotationX, -90, 90); // Ograniczenie kąta obrotu

        // Przypisanie obrotu do kamery
        transform.rotation = Quaternion.Euler(rotationX, transform.rotation.eulerAngles.y + mouseX, 0);

        // Poruszanie postacią
        float horizontalMovement = Input.GetAxis("Horizontal");
        float verticalMovement = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontalMovement, 0, verticalMovement);
        movement = transform.TransformDirection(movement);

        // Sprawdzenie, czy gracz nie opuszcza mapy
        Vector3 newPosition = transform.position + movement * moveSpeed * Time.deltaTime;
        newPosition.x = Mathf.Clamp(newPosition.x, 0, mapSize);
        newPosition.z = Mathf.Clamp(newPosition.z, 0, mapSize);
        transform.position = newPosition;
    }
}
