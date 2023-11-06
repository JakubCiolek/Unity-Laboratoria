using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.UI;
using UnityEngine.UI;

public class CameraSwitcher : MonoBehaviour
{
    public Camera firstCamera; // Pierwsza kamera
    public Camera secondCamera; // Druga kamera
    public Button DrawButton; //przycisk losowania kart
    public GameObject HUD; //panel HUD
    public Button CardButton; //przycisk wyboru karty

    private Camera activeCamera; // Aktualnie aktywna kamera
    

    void Start()
    {
        firstCamera.enabled = false;
        secondCamera.enabled = false;
        // Włącz pierwszą kamerę na początku
        SetActiveCamera(firstCamera);
    }

    void Update()
    {
  
        // Przełączanie między kamerami za pomocą przycisku "C"
        if (HUD.gameObject.activeSelf == true && Input.GetKeyDown(KeyCode.C))
        {
            if (activeCamera == firstCamera){
                SetActiveCamera(secondCamera);
              //ustawianie widocznośći przycisków na wylączone
                CardButton.gameObject.SetActive(false);
                DrawButton.gameObject.SetActive(false);
                }
            else
                {SetActiveCamera(firstCamera);
               //ustawianie widocznośći przycisków na włączone
                CardButton.gameObject.SetActive(false);
                 DrawButton.gameObject.SetActive(true);
                }}
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
