using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;
using TMPro;

public class Plane : MonoBehaviour
{
    // Czy pole jest zajęte
    public bool occupied = false;

    // Obiekt reprezentujący karty
    public GameObject Cards;

    // Plansza gry
    public GameObject GameBoard;

    // Obiekt straży pożarnej
    public GameObject FireStation;

    // Obiekt szpitala
    public GameObject Hospital;

    // Obiekt rynku
    public GameObject Market;

    // Obiekt policyjny
    public GameObject Police;

    // Obiekt pustej karty
    public GameObject CardEmpty;

    // Tekst z liczbą bomb
    public TMP_Text BombCount;

    // Aktualnie umieszczony budynek
    private GameObject currentBuilding;

    private GameObject currentTreeFountain;

    // Skrypt obsługujący bomby
    public Bomb BombScript;

    // Tryb bomby (wartość statyczna)
    private static bool BombMode { get; set; }

    // Nowa karta
    private GameObject newCard;
    public GameObject firTree;
    public GameObject oakTree;
    public GameObject palmTree;
    public GameObject fountain;



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

    // Dodaj komponent kolizji do obiektu
    private void AddCollider(GameObject building)
    {
        if (building != null)
        {
            // Sprawdź, czy obiekt budynku posiada komponent Collider (jeśli nie, to dodaj go)
            Collider collider = building.GetComponent<Collider>();
            if (collider == null)
            {
                // Dodaj komponent Box Collider do budynku (możesz wybrać inny rodzaj kolizji, jeśli jest bardziej odpowiedni)
                building.AddComponent<BoxCollider>();
            }
        }
    }

    // Ustaw tryb bomby
    public bool GetBombMode(bool Mode)
    {
        BombMode = Mode;
        return BombMode;
    }

    // Metoda wywoływana po kliknięciu na obiekt (pole)
    private void OnMouseDown()
    {
        if (BombMode == true)
        {
            int Count = int.Parse(BombCount.text); // Pobierz liczbę z tekstu i przekonwertuj na int

            if (Count < 1)
                BombScript.GetComponent<Bomb>().OnBombClick();
            else if (occupied) // Sprawdzamy, czy pole jest zajęte (ma budynek)
            {
                Destroy(currentBuilding); // Usuwamy budynek z pola
                Destroy(newCard);
                Destroy(currentTreeFountain);
                
                occupied = false; // Oznaczamy pole jako niezajęte
                Count--; // Zmniejsz wartość o 1
                BombCount.text = Count.ToString(); // Zaktualizuj tekst na podstawie zmienionej wartości Count
                Cards.GetComponent<Cards>().ChangeCounter();
                BombScript.GetComponent<Bomb>().OnBombClick();
            }
        }
        else if (!occupied && Cards.GetComponent<Cards>().CardChoosen)
        {
            // Oblicz pozycję docelową dla obiektu na podstawie środka obiektu
            Vector3 objectCenter = transform.position;

            // Uzyskaj wybraną kartę z komponentu "Cards"
            string card = Cards.GetComponent<Cards>().cardPick;

            // Usuń cyfry z nazwy karty
            string output = Regex.Replace(card, @"[\d-]", string.Empty);

                        // Twórz nową kartę pustą na polu
            newCard = Instantiate(CardEmpty, new Vector3(objectCenter.x, 0.1f, objectCenter.z), CardEmpty.transform.rotation);
            MeshRenderer meshRenderer = newCard.GetComponent<MeshRenderer>();
            meshRenderer.material = Resources.Load<Material>("CardTextures/Blue_PlayingCards_" + card + "_00");

            // Oznacz pole jako zajęte i wywołaj metodę "CardPlaced" w komponencie "Cards"
            occupied = true;
            Cards.GetComponent<Cards>().CardPlaced(1);

            // W zależności od rodzaju karty, twórz odpowiednie obiekty na polu
            switch (output)
            {
                case "Diamond":
                    currentBuilding = Instantiate(FireStation, new Vector3(objectCenter.x, objectCenter.y, objectCenter.z), FireStation.transform.rotation);
                    AddCollider(currentBuilding);
                    GenerateTreeorFountain(10, currentBuilding);
                    break;
                case "Heart":
                    currentBuilding = Instantiate(Hospital, new Vector3(objectCenter.x, objectCenter.y, objectCenter.z), Hospital.transform.rotation);
                    AddCollider(currentBuilding);
                    GenerateTreeorFountain(10, currentBuilding);
                    break;
                case "Club":
                    currentBuilding = Instantiate(Market, new Vector3(objectCenter.x, objectCenter.y, objectCenter.z), Market.transform.rotation);
                    AddCollider(currentBuilding);
                    GenerateTreeorFountain(10, currentBuilding);
                    break;
                case "Spade":
                    currentBuilding = Instantiate(Police, new Vector3(objectCenter.x, objectCenter.y, objectCenter.z), Police.transform.rotation);
                    AddCollider(currentBuilding);
                    GenerateTreeorFountain(10, currentBuilding);
                    break;
                default:
                    break;
            }
            currentBuilding.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        }
    }

    private void GenerateTreeorFountain(int chance , GameObject card)
    {
        Vector3 randomCorner = GetCoordinatesForBonus(card);

        int random = Random.Range(1,10);
        if(random <= chance)
        {
            random = Random.Range(0,4);
            switch(random)
            {
                case 0:
                    currentTreeFountain = Instantiate(oakTree, randomCorner, oakTree.transform.rotation);
                    break;
                case 1:
                    currentTreeFountain = Instantiate(palmTree, randomCorner, palmTree.transform.rotation);
                    break;
                case 2:
                    currentTreeFountain = Instantiate(firTree, randomCorner, firTree.transform.rotation);
                    break;
                case 3:
                    randomCorner.y = 0.1f;
                    currentTreeFountain = Instantiate(fountain, randomCorner, fountain.transform.rotation);
                    break;
                default:
                    break;
            }
        }
    }

    private Vector3 GetCoordinatesForBonus(GameObject obj)
    {
        Renderer objRenderer = obj.GetComponent<Renderer>();

        if (objRenderer != null)
        {
            Bounds objBounds = objRenderer.bounds;

            // Wybierz losowy punkt wewnątrz granic obiektu
            Vector3 buildingCenter = objBounds.center;
            buildingCenter.y = 0f;

            while(objBounds.Contains(buildingCenter))
            {
                buildingCenter.x +=Random.Range(0f,0.1f);;
                buildingCenter.z +=Random.Range(0f,0.1f);;
            }
            return buildingCenter;

        }
        else
        {
            Debug.LogError("Object is missing Renderer component.");
            return Vector3.zero;
        }
    }
}
