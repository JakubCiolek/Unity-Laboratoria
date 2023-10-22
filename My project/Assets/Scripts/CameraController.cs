using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public Transform target; // Obiekt, wokó³ którego kamera bêdzie obracana
    public float rotationSpeed = 20.0f;
    public float zoomSpeed = 5.0f;
    public float minDistance = 5.0f;
    public float maxDistance = 20.0f;
    private float distanceToTarget;
    private float currentRotation = 0.0f;

    void Start()
    {
        distanceToTarget = Vector3.Distance(transform.position, target.position);
    }

    void Update()
    {
        // Obracanie kamery w lewo
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            currentRotation += rotationSpeed * Time.deltaTime;
        }

        // Obracanie kamery w prawo
        if (Input.GetKey(KeyCode.RightArrow))
        {
            currentRotation -= rotationSpeed * Time.deltaTime;
        }
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        distanceToTarget = Mathf.Clamp(distanceToTarget - scroll * zoomSpeed, minDistance, maxDistance);

        Vector3 offset = new Vector3(0, 0, -distanceToTarget);
        Quaternion rotation = Quaternion.Euler(20, currentRotation, 0);
        Vector3 newPosition = target.position + rotation * offset;

        transform.position = newPosition;
        transform.LookAt(target);
    }
}
