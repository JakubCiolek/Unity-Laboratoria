using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Cards : MonoBehaviour
{
    string[] cardsList = { "Club01", "Club02", "Club03", "Club04", "Club05", "Club06", "Club07", "Club08", "Club09", "Club10", "Club11", "Club12", "Club13",
                                "Diamond01", "Diamond02", "Diamond03", "Diamond04", "Diamond05", "Diamond06", "Diamond07", "Diamond08", "Diamond09", "Diamond10", "Diamond11", "Diamond12", "Diamond13",
                                "Heart01", "Heart02", "Heart03", "Heart04", "Heart05", "Heart06", "Heart07", "Heart08", "Heart09", "Heart10", "Heart11", "Heart12", "Heart13",
                                "Spade01", "Spade02", "Spade03", "Spade04", "Spade05", "Spade06", "Spade07", "Spade08", "Spade09", "Spade10", "Spade11", "Spade12", "Spade13"};
    public Button Card1;    
    public Button Card2;
    public Button Card3;
    public Button Card4;

    public bool CardChoosen = false;
    public Sprite CardChoosenName;

    int Counter = 0;

    public void RandomCards() {
        if(Counter < 4){
            System.Random rnd = new System.Random();

            string card1 = cardsList[rnd.Next(cardsList.Length)];
            string card2 = cardsList[rnd.Next(cardsList.Length)];
            string card3 = cardsList[rnd.Next(cardsList.Length)];
            string card4 = cardsList[rnd.Next(cardsList.Length)];

            Card1.GetComponent<Image>().sprite = Resources.Load<Sprite>(card1);
            Card2.GetComponent<Image>().sprite = Resources.Load<Sprite>(card2);
            Card3.GetComponent<Image>().sprite = Resources.Load<Sprite>(card3);
            Card4.GetComponent<Image>().sprite = Resources.Load<Sprite>(card4);

            Card1.gameObject.SetActive(true);
            Card2.gameObject.SetActive(true);
            Card3.gameObject.SetActive(true);
            Card4.gameObject.SetActive(true);
            CardChoosen = false;
            Counter++;
        }
    }

    public void ChooseCard(int i){
        
            Card1.gameObject.SetActive(false);
            Card2.gameObject.SetActive(false);
            Card3.gameObject.SetActive(false);
            Card4.gameObject.SetActive(false);
        switch(i){
        case 1:
            Card1.gameObject.SetActive(true);
            CardChoosenName = Card1.GetComponent<Image>().sprite;
            CardChoosen = true;
            break;
        case 2:
            Card2.gameObject.SetActive(true);
            CardChoosenName = Card2.GetComponent<Image>().sprite;
            CardChoosen = true;
            break;
        case 3:
            Card3.gameObject.SetActive(true);
            CardChoosenName = Card3.GetComponent<Image>().sprite;
            CardChoosen = true;
            break;
        case 4:
            Card4.gameObject.SetActive(true);
            CardChoosenName = Card4.GetComponent<Image>().sprite;
            CardChoosen = true;
            break;
        default:
            Card1.gameObject.SetActive(true);
            Card2.gameObject.SetActive(true);
            Card3.gameObject.SetActive(true);
            Card4.gameObject.SetActive(true);
            CardChoosen = false;
            break;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        RandomCards();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
