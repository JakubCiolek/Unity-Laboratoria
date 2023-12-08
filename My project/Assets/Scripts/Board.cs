using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Board : MonoBehaviour
{
    public GameObject tilePrefab; // Prefabrykat dla pojedynczego kafelka (pola na planszy)
    public int rows = 2; // Liczba wierszy na planszy
    public int columns = 2; // Liczba kolumn na planszy

    // Metoda Start wywoływana przy starcie gry
    void Start()
    {
        CreateBoard(); // Tworzenie planszy
    }

    // Metoda do tworzenia planszy z kafelkami
    void CreateBoard()
    {
        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < columns; col++)
            {
                // Oblicz pozycję dla każdego kafelka na podstawie indeksu wiersza i kolumny
                Vector3 position = new Vector3(col * 10, 0, row * 10); // Zakładamy, że każdy kafelek ma rozmiar 10x10 jednostek w jednostkach Unity.

                // Tworzenie nowego kafelka na podstawie prefabu i ustawienie pozycji
                GameObject tile = Instantiate(tilePrefab, position, Quaternion.identity);
                tile.gameObject.tag = "tile" +row.ToString() + col.ToString();
                Plane plane = tile.GetComponent<Plane>();
                plane.InitrializePos(row,col);
                // Opcjonalnie możesz dostosować inne cechy kafelka, takie jak kolor, teksturę, itp.
                // tile.GetComponent<Renderer>().material.color = Color.white;
            }
        }
    }

    // Metoda do umieszczania budynków na planszy (nie jest jeszcze zaimplementowana)
    void PlaceBuilding()
    {
        // Przygotuj kod do umieszczania budynków na planszy
        // Przykładowo, uzyskaj pozycję, na której chcesz umieścić budynek i użyj Instantiate.
        Vector3 position = tilePrefab.transform.position;
        //GameObject tile = Instantiate(cube, position, Quaternion.identity);
    }
}
