using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.UI;

public class Level : MonoBehaviour
{
    // Przyciski do wyboru poziomu trudności
    public Button Easy;
    public Button Medium;
    public Button Hard;
    public Button DrawButton;
    public GameObject HUD;
    public GameObject InfoPanel;
    public TMP_Text UserNickname;
    public TMP_Text InfoText;

    // Obiekty canvas dla menu początkowego i kart
    public Canvas startMenu;
    public Canvas Cards;

    // Pole do wprowadzenia nicku gracza
    public TMP_InputField inputNickname;

    // Zmienne przechowujące nick gracza i wybrany poziom trudności
    public string nickname = "";
    public int choosenLevel = 0;

    // Metoda do wyboru poziomu trudności
    public void ChooseLevel(int level)
    {
        // Zresetowanie koloru przycisków poziomu trudności
        Easy.gameObject.GetComponent<Image>().color = Color.white;
        Medium.gameObject.GetComponent<Image>().color = Color.white;
        Hard.gameObject.GetComponent<Image>().color = Color.white;

        // Ustawienie koloru wybranego przycisku na szary
        switch (level)
        {
            case 1:
                Easy.gameObject.GetComponent<Image>().color = Color.grey;
                choosenLevel = 1;
                break;
            case 2:
                Medium.gameObject.GetComponent<Image>().color = Color.grey;
                choosenLevel = 2;
                break;
            case 3:
                Hard.gameObject.GetComponent<Image>().color = Color.grey;
                choosenLevel = 3;
                break;
            default:
                break;
        }
    }

    // Metoda rozpoczęcia gry
    public void StartGame()
    {
    
        if (choosenLevel != 0 && nickname.Length != 0)
        {
            UserNickname.text = nickname;
            DrawButton.interactable = true;
            HUD.gameObject.SetActive(true);
            Debug.Log(nickname + choosenLevel);
            Cards.gameObject.SetActive(true);
            startMenu.gameObject.SetActive(false);
            InfoPanel.gameObject.SetActive(false);
            
        }
        else {
            //wysweitlenie informacji o braku danych
            InfoPanel.gameObject.SetActive(true);
            InfoText.text = "Please choose difficulty level and nickname";
        }
    }

    // Metoda wywoływana przy zmianie wartości w polu wprowadzania nicku
    public void NicknameValueChanged(string n)
    {
        nickname = inputNickname.text;
    }

    // Metoda Start - wywoływana przy starcie gry
    void Start()
    {
        InfoPanel.gameObject.SetActive(false);
        HUD.gameObject.SetActive(false);
        DrawButton.interactable = false;
        Cards.gameObject.SetActive(false);
    }

    // Metoda Update - brak implementacji
    void Update()
    {

    }
}
