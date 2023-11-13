using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.UI;
using UnityEngine.UI;
using Unity.VisualScripting;

public class CameraSwitcher : MonoBehaviour
{
    public Camera firstCamera; // Pierwsza kamera
    public Camera secondCamera; // Druga kamera
    public Button DrawButton; //przycisk losowania kart
    public GameObject HUD; //panel HUD
    public Button CardButton; //przycisk wyboru karty

    private Camera activeCamera; // Aktualnie aktywna kamera

    public GameObject firstPersonController;

    void Start()
    {
        //firstCamera.enabled = false;
        firstPersonController.gameObject.SetActive(false);
        secondCamera = firstPersonController.GetComponent<Camera>();
        // Włącz pierwszą kamerę na początku
        firstCamera.enabled = true;
    }

    void Update()
    {
  
        // Przełączanie między kamerami za pomocą przycisku "C"
        if (HUD.gameObject.activeSelf == true && Input.GetKeyDown(KeyCode.C))
        {
            if (activeCamera == firstCamera)
            {
                //firstPersonController = Instantiate(firstPersonController, new Vector3(objectCenter.x, 0.1f, objectCenter.z));
                firstPersonController.gameObject.SetActive(true);
                SetActiveCamera(secondCamera);
                Cursor.lockState = CursorLockMode.Locked;
              //ustawianie widocznośći przycisków na wylączone
                CardButton.gameObject.SetActive(false);
                DrawButton.gameObject.SetActive(false);
            }
            else
            {
                SetActiveCamera(firstCamera);
                firstPersonController.gameObject.SetActive(false);
                Cursor.lockState = CursorLockMode.None;
               //ustawianie widocznośći przycisków na włączone
                CardButton.gameObject.SetActive(false);
                DrawButton.gameObject.SetActive(true);
            }
        }
    }

    void SetActiveCamera(Camera newActiveCamera)
    {
        // Wyłącz poprzednią aktywną kamerę
        if (activeCamera != null)
            activeCamera.enabled = false;

        // Ustaw nową kamerę jako aktywną
        activeCamera = newActiveCamera;
        activeCamera.enabled = true;
    }
}
