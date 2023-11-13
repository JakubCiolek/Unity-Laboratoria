using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public CharacterController controller;
    public float mouseSensitivity = 1000.0f; // Czułość myszy
    public float moveSpeed = 5.0f; // Prędkość poruszania się kamery
    public float mapSize = 30f; 

    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        UnityEngine.Vector3 movement = transform.right * x + transform.forward * z;

        controller.Move(movement*moveSpeed * Time.deltaTime);

                // Sprawdzenie, czy gracz nie opuszcza mapy
        UnityEngine.Vector3 newPosition = transform.position + movement * moveSpeed * Time.deltaTime;
        newPosition.x = Mathf.Clamp(newPosition.x, 0, mapSize);
        newPosition.z = Mathf.Clamp(newPosition.z, 0, mapSize);
        transform.position = newPosition;
    }
}
