using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Cards : MonoBehaviour
{
    // Lista kart do wyboru
    //List<string> cardsList = new() { "Club07", "Club13", "Heart12", "Joker_Color" }; // zmieniłem tutaj żeby losować tylko te karty co mają tą naszą teksture 
    List<Card> ListOfCards = new() {new Card("Club07"), new Card("Club13"), new Card("Heart12"), new Card("Spade06")};
    // Przycisk reprezentujący pierwszą kartę
    public Button Card1;

    // Zmienne do śledzenia wybranej karty
    public bool CardChoosen = false;
    public string cardPick;
    public string card1;
    public string card2;
    public string card3;
    public string card4;


    // Licznik, aby kontrolować ilość wybranych kart
    int Counter = 0;

    // Metoda służąca do modyfikacji licznika
    public void ChangeCounter(){
        Counter--;
    }
    // Metoda wywoływana, gdy karta jest umieszczana
    public void CardPlaced(int i)
    {
        // Ukrycie karty i zresetowanie zmiennych
        Card1.gameObject.SetActive(false);
        cardPick = "";
        CardChoosen = false;
    }

    // Metoda do losowania kart
    public void RandomCards()
    {
        if (Counter == 0)
        Card1.gameObject.SetActive(true);
        if (Counter < 4 )
        {
            System.Random rnd = new System.Random();

            card1 = ListOfCards[rnd.Next(ListOfCards.Count)].Name;
            //card2 = cardsList[rnd.Next(cardsList.Count)];
            //card3 = cardsList[rnd.Next(cardsList.Count)];
            //card4 = cardsList[rnd.Next(cardsList.Count)];

            Card1.GetComponent<Image>().sprite = Resources.Load<Sprite>(card1);
            //Card2.GetComponent<Image>().sprite = Resources.Load<Sprite>(card2);
            //Card3.GetComponent<Image>().sprite = Resources.Load<Sprite>(card3);
            //Card4.GetComponent<Image>().sprite = Resources.Load<Sprite>(card4);

            Card1.gameObject.SetActive(true);
            ChooseCard(1);
            //Card2.gameObject.SetActive(true);
            //Card3.gameObject.SetActive(true);
            //Card4.gameObject.SetActive(true);
            //CardChoosen = false;
            //cardPick = "";
            Counter++;
        }
    }

    // Metoda do wyboru karty
    public void ChooseCard(int i)
    {
        
        Card1.gameObject.SetActive(false);
        //Card2.gameObject.SetActive(false);
        //Card3.gameObject.SetActive(false);
        //Card4.gameObject.SetActive(false);
        switch (i)
        {
            case 1:
           
                Card1.gameObject.SetActive(true);
                cardPick = card1;
                CardChoosen = true;
                break;
            // case 2:
            //     Card2.gameObject.SetActive(true);
            //     cardPick = card2;
            //     CardChoosen = true;
            //     break;
            // case 3:
            //     Card3.gameObject.SetActive(true);
            //     cardPick = card3;
            //     CardChoosen = true;
            //     break;
            // case 4:
            //     Card4.gameObject.SetActive(true);
            //     cardPick = card4;
            //     CardChoosen = true;
            //     break;
            default:
                Card1.gameObject.SetActive(true);
                //Card2.gameObject.SetActive(true);
                //Card3.gameObject.SetActive(true);
                //Card4.gameObject.SetActive(true);
                //CardChoosen = false;
                break;
        }
    }

    // Metoda wywoływana przy starcie
    void Start()
    {
        Card1.gameObject.SetActive(false);
       // RandomCards();
    }

    // Metoda Update - brak implementacji
    void Update()
    {

    }
}
