using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public Texture2D cursorTexture;
    private bool isBombMode { get; set; } // Flaga trybu bomby
    public Plane PlaneScript; // Skrypt klasy Plane, który obsługuje pole gry

    private void Start()
    {
        isBombMode = false; // Tryb bomby jest początkowo wyłączony
    }

    // Metoda wywoływana po kliknięciu na przycisk "Bomba"
    public void OnBombClick()
    {
        isBombMode = !isBombMode; // Zmiana stanu trybu bomby (włącz/wyłącz)
        PlaneScript.GetComponent<Plane>().GetBombMode(isBombMode); // Przekaż stan trybu bomby do skryptu Plane
        UpdateCursor(); // Zaktualizuj wygląd kursora
    }

    // Aktualizacja wyglądu kursora
    private void UpdateCursor()
    {
        if (isBombMode)
        {
            Cursor.SetCursor(cursorTexture, Vector2.zero, CursorMode.Auto); // Ustaw teksturę kursora na tryb bomby
        }
        else
        {
            Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto); // Przywróć domyślny kursor
        }
    }

    // Wyświetl bieżący stan trybu bomby w konsoli
    public void PrintCurrentMode()
    {
        Debug.Log(isBombMode);
    }
}
