using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target; // Obiekt, wokół którego kamera będzie obracana
    public float rotationSpeed = 20.0f; // Prędkość obracania kamery
    public float zoomSpeed = 5.0f; // Prędkość przybliżania i oddalania kamery
    public float minDistance = 5.0f; // Minimalna odległość kamery od obiektu docelowego
    public float maxDistance = 20.0f; // Maksymalna odległość kamery od obiektu docelowego

    private float distanceToTarget; // Aktualna odległość kamery od obiektu docelowego
    private float currentRotation = 0.0f; // Aktualny kąt obrotu kamery

    void Start()
    {
        // Oblicz początkową odległość kamery od obiektu docelowego
        distanceToTarget = Vector3.Distance(transform.position, target.position);
    }

    void Update()
    {
        // Obracanie kamery w lewo (kiedy lewy strzałka jest wciśnięta)
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            currentRotation += rotationSpeed * Time.deltaTime;
        }

        // Obracanie kamery w prawo (kiedy prawy strzałka jest wciśnięta)
        if (Input.GetKey(KeyCode.RightArrow))
        {
            currentRotation -= rotationSpeed * Time.deltaTime;
        }

        // Przybliżanie i oddalanie kamery za pomocą rolki myszy (Mouse ScrollWheel)
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        distanceToTarget = Mathf.Clamp(distanceToTarget - scroll * zoomSpeed, minDistance, maxDistance);

        // Obliczenie nowej pozycji kamery na podstawie obrotu i odległości od obiektu docelowego
        Vector3 offset = new Vector3(0, 0, -distanceToTarget);
        Quaternion rotation = Quaternion.Euler(20, currentRotation, 0);
        Vector3 newPosition = target.position + rotation * offset;

        // Aktualizacja pozycji i ustawienia kamery
        transform.position = newPosition;
        transform.LookAt(target);
    }
}
