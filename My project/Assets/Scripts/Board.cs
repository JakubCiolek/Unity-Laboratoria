using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    public GameObject tilePrefab; // Prefab dla kafelka
    public GameObject cube; // Prefab kostka
    public int rows = 2; // Liczba wierszy
    public int columns = 2; // Liczba kolumn

    void Start()
    {
        CreateBoard();
    }

    void CreateBoard()
    {
        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < columns; col++)
            {
                // Oblicz pozycjê dla ka¿dego kafelka
                Vector3 position = new Vector3(col * 2, 0, row * 2); // Zak³adam, ¿e ka¿dy kafelek ma rozmiar 2x2 w jednostkach Unity.

                // Tworzenie nowego kafelka na podstawie prefabu i ustawienie pozycji
                GameObject tile = Instantiate(tilePrefab, position, Quaternion.identity);

                // Opcjonalnie mo¿esz dostosowaæ inny aspekt kafelka, takie jak kolor, teksturê, itp.
                // tile.GetComponent<Renderer>().material.color = Color.white;
            }
        }
    }
    void PlaceBuilding() { 
        Vector3 position = tilePrefab.transform.position;
        GameObject tile = Instantiate(cube, position, Quaternion.identity);
    }
}
