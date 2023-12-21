using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class Difficulty : MonoBehaviour
{
    public GameObject ButtonPrefab; // Prefabrykat przycisku
    public Transform ButtonContainer; // Kontener na przyciski
    public List<DifficultyLevel> DifficultyLevels;  // Lista poziomów trudności
    private string Nickname = ""; // Nazwa gracza
    public Button DrawButton; // Przycisk rysowania
    public GameObject HUD; // Interfejs użytkownika
    public Canvas Cards; // Karty
    public Button BombButton; // Przycisk bomby
    public GameObject InfoPanel; // Panel informacyjny
    public TMP_Text UserNickname; // Tekst z nazwą gracza
    public Image DifImage; // Ikona poziomu trudności
    public TMP_Text InfoText; // Tekst informacyjny
    public TMP_Text BombCount; // Liczba bomb
    public TMP_Text MinMaxText; // Liczba min i max poziomu
    public Canvas startMenu; // Menu początkowe
    public TMP_InputField inputNickname; // Pole do wprowadzania nazwy gracza
    private bool Picked = false; // Flaga wskazująca, czy wybrano poziom trudności
    public DifficultyLevel Lvl; // Aktualnie wybrany poziom trudności
    public Cards CardsScript; // Skrypt kart
    // Ikony trudności
    public Sprite EasyIcon; 
    public Sprite MediumIcon;
    public Sprite HardIcon;

    private List<Button> createdButtons = new List<Button>(); // Lista przechowująca utworzone przyciski

    private void Start()
    {
       DifficultyLevels = new List<DifficultyLevel>
    {
        new DifficultyLevel
        {
            LevelName = "Easy",
            Icon = EasyIcon,
            NumberOfBombs = 3,
            RedrawCount = 8,
            Parameters = new List<Parameter>
            {
                new Parameter { Key = "min", ValueConretePercentage = 10,
                ValueGreenPercentage = 15, ValueFlatAvg = 50, ValueTreesAvg = 10},
                new Parameter { Key = "max", ValueConretePercentage = 50,
                ValueGreenPercentage = 70, ValueFlatAvg = 130, ValueTreesAvg = 50}
            }
        },
        new DifficultyLevel
        {
            LevelName = "Medium",
            Icon = MediumIcon,
            NumberOfBombs = 2,
            RedrawCount = 6,
            Parameters = new List<Parameter>
            {
                new Parameter { Key = "min", ValueConretePercentage = 15,
                ValueGreenPercentage = 20, ValueFlatAvg = 60, ValueTreesAvg = 15},
                new Parameter { Key = "max", ValueConretePercentage = 40,
                ValueGreenPercentage = 60, ValueFlatAvg = 110, ValueTreesAvg = 40}
            }
        },
        new DifficultyLevel
        {
            LevelName = "Hard",
            Icon = HardIcon,
            NumberOfBombs = 1,
            RedrawCount = 4,
            Parameters = new List<Parameter>
            {
                new Parameter { Key = "min", ValueConretePercentage = 20,
                ValueGreenPercentage = 30, ValueFlatAvg = 70, ValueTreesAvg = 20},
                new Parameter { Key = "max", ValueConretePercentage = 30,
                ValueGreenPercentage = 50, ValueFlatAvg = 90, ValueTreesAvg = 30}
            }
        }
    };
        GenerateButtons(); // Generuj przyciski na starcie
        InfoPanel.gameObject.SetActive(false); // Ukryj panel informacyjny
        HUD.gameObject.SetActive(false); // Ukryj interfejs użytkownika
        DrawButton.interactable = false; // Dezaktywuj przycisk rysowania
        Cards.gameObject.SetActive(false); // Ukryj karty
    }

    // Metoda wywoływana po zmianie tekstu w polu wprowadzania nazwy gracza
    public void NicknameValueChanged(string n)
    {
        Nickname = inputNickname.text; // Zapisz wprowadzoną nazwę gracza
    }

    private void GenerateButtons()
    {
        float buttonSpacing = 200f; // Odległość między przyciskami
        Vector3 buttonPosition = Vector3.zero; // Pozycja początkowa

        foreach (DifficultyLevel level in DifficultyLevels)
        {
            GameObject buttonObject = Instantiate(ButtonPrefab, ButtonContainer); // Utwórz przycisk
            TextMeshProUGUI buttonText = FindTextMeshProInChildren(buttonObject); // Znajdź komponent TextMeshProUGUI

            if (buttonText != null)
            {
                buttonText.text = level.LevelName; // Ustaw nazwę poziomu trudności na przycisku
            }
            else
            {
                Debug.LogError("Nie znaleziono komponentu TextMeshProUGUI w przycisku.");
            }

            buttonObject.transform.localPosition = buttonPosition; // Ustaw pozycję przycisku

            buttonPosition.x += buttonSpacing; // Zaktualizuj pozycję przycisku na osi X

            Image buttonImage = null;

            foreach (var image in buttonObject.GetComponentsInChildren<Image>())
            {
                if (image.transform.parent == buttonObject.transform)
                {
                    buttonImage = image; // Znajdź komponent Image wewnątrz przycisku
                    break;
                }
            }

            if (buttonImage != null)
            {
                buttonImage.sprite = level.Icon; // Ustaw ikonę poziomu trudności na przycisku
            }
            else
            {
                Debug.LogError("Nie znaleziono komponentu Image wewnętrznego przycisku.");
            }

            Button levelButton = buttonObject.GetComponent<Button>();
            levelButton.onClick.AddListener(() => OnLevelButtonClicked(level, buttonObject)); // Dodaj obsługę kliknięcia przycisku

            createdButtons.Add(levelButton); // Dodaj przycisk do listy
        }
    }

    private TextMeshProUGUI FindTextMeshProInChildren(GameObject parent)
    {
        TextMeshProUGUI[] textComponents = parent.GetComponentsInChildren<TextMeshProUGUI>(true);
        return textComponents.Length > 0 ? textComponents[0] : null;
    }

    private void OnLevelButtonClicked(DifficultyLevel level, GameObject buttonObject)
    {
        Lvl = level; // Zapisz wybrany poziom trudności

        Picked = true; // Ustaw flagę wyboru poziomu

        // Resetuj kolory wszystkich przycisków
        foreach (Button button in createdButtons)
        {
            button.GetComponent<Image>().color = Color.white;
        }

        buttonObject.GetComponent<Image>().color = Color.grey; // Zmień kolor wybranego przycisku na szary
    }

    public void StartGame()
    {
        if (Nickname.Length != 0 && Picked == true)
        {
            CardsScript.GetComponent<Cards>().GetDifficultyLevel(Lvl);
            UserNickname.text = Nickname; // Ustaw nazwę gracza
            DrawButton.interactable = true; // Aktywuj przycisk rysowania
            HUD.gameObject.SetActive(true); // Aktywuj interfejs użytkownika
            Cards.gameObject.SetActive(true); // Aktywuj karty
            startMenu.gameObject.SetActive(false); // Ukryj menu początkowe
            InfoPanel.gameObject.SetActive(false); // Ukryj panel informacyjny
            DifImage.sprite = Lvl.Icon; // Ustaw ikonę poziomu trudności
            BombCount.text = Lvl.NumberOfBombs.ToString(); // Ustaw liczbę bomb
            // Ustawienie tekstu parametrów

            Parameter minText = Lvl.Parameters.FirstOrDefault(p => p.Key == "min");
            Parameter maxText = Lvl.Parameters.FirstOrDefault(p => p.Key == "max");
            string concrete = "Concrete: " + minText.ValueConretePercentage   + "% - " + maxText.ValueConretePercentage + "%\n";
            string green = "Green: " + minText.ValueGreenPercentage   + "% - " + maxText.ValueGreenPercentage + "%\n";
            string flat = "Flats: " + minText.ValueFlatAvg  + " - " + maxText.ValueFlatAvg + " average per card\n";
            string trees = "Trees: " + minText.ValueTreesAvg  + " - " + maxText.ValueTreesAvg + " average per card\n";
            string parametersText = concrete + green + flat + trees;
            MinMaxText.text = parametersText;
        }
        else
        {
            // Wyświetlenie informacji o braku danych
            InfoPanel.gameObject.SetActive(true);
            InfoText.text = "Wybierz poziom trudności i podaj nazwę gracza.";
        }
    }
    
}

[System.Serializable]
public class DifficultyLevel
{
    public string LevelName; // Nazwa poziomu trudności
    public Sprite Icon; // Ikona poziomu trudności
    public int NumberOfBombs; // Liczba bomb
    public int RedrawCount; // Liczba ponownych losowań karty
    public List<Parameter> Parameters = new List<Parameter>(); // Lista parametrów
}

[System.Serializable]
public class Parameter
{
    public string Key;
    public int ValueConretePercentage;
    public int ValueGreenPercentage;
    public int ValueFlatAvg;
    public int ValueTreesAvg;
}

