using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;

public class Plane : MonoBehaviour
{
    public bool occupied = false; // Czy pole jest zajęte
    public GameObject Cards; // Obiekt reprezentujący karty
    public GameObject GameBoard; // Plansza gry
    public GameObject FireStation; // Obiekt straży pożarnej
    public GameObject Hospital; // Obiekt szpitala
    public GameObject Market; // Obiekt rynku
    public GameObject Police; // Obiekt policyjny
    public GameObject CardEmpty; // Obiekt pustej karty

    // Metoda wywoływana przy starcie
    void Start()
    {
        // Brak implementacji w tym przypadku
    }

    // Metoda Update - brak implementacji
    void Update()
    {
        // Brak implementacji w tym przypadku
    }

    // Metoda wywoływana po kliknięciu na obiekt (pole)
    private void OnMouseDown()
    {
        if (occupied == false && Cards.GetComponent<Cards>().CardChoosen == true)
        {
            // Oblicz pozycję docelową dla obiektu na podstawie środka obiektu
            Vector3 objectCenter = transform.position;

            // Uzyskaj wybraną kartę z komponentu "Cards"
            string card = Cards.GetComponent<Cards>().cardPick;

            // Usuń cyfry z nazwy karty
            string output = Regex.Replace(card, @"[\d-]", string.Empty);

            // W zależności od rodzaju karty, twórz odpowiednie obiekty na polu
            switch (output)
            {
                case "Diamond":
                    Instantiate(FireStation, new Vector3(objectCenter.x, objectCenter.y, objectCenter.z), FireStation.transform.rotation);
                    break;
                case "Heart":
                    Instantiate(Hospital, new Vector3(objectCenter.x, objectCenter.y, objectCenter.z), Hospital.transform.rotation);
                    break;
                case "Club":
                    Instantiate(Market, new Vector3(objectCenter.x, objectCenter.y, objectCenter.z), Market.transform.rotation);
                    break;
                case "Spade":
                    Instantiate(Police, new Vector3(objectCenter.x, objectCenter.y, objectCenter.z), Police.transform.rotation);
                    break;
                default:
                    break;
            }

            // Twórz nową kartę pustą na polu
            GameObject newCard = Instantiate(CardEmpty, new Vector3(objectCenter.x, 0.1f, objectCenter.z), CardEmpty.transform.rotation);
            MeshRenderer meshRenderer = newCard.GetComponent<MeshRenderer>();
            meshRenderer.material = Resources.Load<Material>("CardTextures/Blue_PlayingCards_" + card + "_00");
            
            // Oznacz pole jako zajęte i wywołaj metodę "CardPlaced" w komponencie "Cards"
            occupied = true;
            Cards.GetComponent<Cards>().CardPlaced(1);
        }
    }
}
