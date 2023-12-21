using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class PlacingCard : MonoBehaviour
{
    // Start is called before the first frame update

    public EndGame endGame;

    public TMP_Text bombs;
    public Difficulty difficultyObj;

    int difficulty=0;

    public int concrete = 0;
    public int green = 0;
    public int flats = 0;
    public int trees = 0;

    public string[,] planeMatrix = {
            {"none", "none"},
            {"none", "none"}
        };
    void Start()
    {
        string temp = difficultyObj.Lvl.LevelName;
        if(temp == "Easy")
        {
            difficulty = 1;
        }
        else if(temp == "Medium")
        {
            difficulty = 2;
        }
        else
        {
            difficulty = 3;
        }
    }

    // Update is called once per frame
    void Update()
    {
        CheckEndGame();
    }

    public void SaveCardType(int x, int y, string type)
    {
        planeMatrix[x,y] = type;
    }

    public bool CanCardBePlaced(string cardType, int x, int y)
    {
        switch(x,y)
        {
            case (0,0):
                if(planeMatrix[1,0] == cardType || planeMatrix[0,1] == cardType)
                {
                    Debug.Log("nie można dać kart tego samego koloru obok siebie");
                    return false;
                }
                return true;
            case (0,1):
                if(planeMatrix[1,1] == cardType || planeMatrix[0,0] == cardType)
                {
                    Debug.Log("nie można dać kart tego samego koloru obok siebie");
                    return false;
                }
                return true;
            case (1,0):
                if(planeMatrix[0,0] == cardType || planeMatrix[1,1] == cardType)
                {
                    Debug.Log("nie można dać kart tego samego koloru obok siebie");
                    return false;
                }
                return true;
            case (1,1):
                if(planeMatrix[1,0] == cardType || planeMatrix[0,1] == cardType)
                {
                    Debug.Log("nie można dać kart tego samego koloru obok siebie");
                    return false;
                }
                return true;
            default:
                return false;
        }
    }

    public void CheckEndGame()
    {
        concrete = 0;
        green = 0;
        flats = 0;
        trees = 0;
        bool gameEnd = true;
        foreach(string card in planeMatrix)
        {
            if(card == "Diamond")
            {
                flats += 30;
                green += 20;
                trees += 20;
                concrete += 20;
            }
            if(card == "Heart")
            {
                flats += 150;
                green += 10;
                trees+= 5;
                concrete += 30;
            }
            if(card == "Club")
            {
                flats += 70;
                green += 10;
                trees += 15;
                concrete += 10;
            }
            if(card == "Spade")
            {
                flats += 70;
                green += 0;
                trees += 50;
                concrete += 5;
            }
            if(card == "none")
            {
                gameEnd = false;
            }
        }
        if (gameEnd)
        {
            switch(difficulty)
            {
                case 1:
                    if((concrete >= 10 && concrete <= 50) && 
                        (flats/4 >= 50 && flats/4 <= 130) && 
                        (green >= 15 && green <= 70) && 
                        (trees/4 >= 10 && trees/4 <= 50))
                    {
                        endGame.Win();
                    }
                    else if (bombs.text == "0")
                    {
                        endGame.Defeat();
                    }
                    break;
                case 2:
                    if((concrete >= 15 && concrete <= 40) && 
                        (flats/4 >= 60 && flats/4 <= 110) && 
                        (green >= 20 && green <= 60) && 
                        (trees/4 >= 15 && trees/4 <= 40))
                    {
                        endGame.Win();
                    }
                    else if (bombs.text == "0")
                    {
                        endGame.Defeat();
                    }
                    break;
                case 3:
                    if((concrete >= 20 && concrete <= 30) && 
                        (flats/4 >= 70 && flats/4 <= 90) && 
                        (green >= 30 && green <= 50) && 
                        (trees/4 >= 20 && trees/4 <= 30))
                    {
                        endGame.Win();
                    }
                    else if (bombs.text == "0")
                    {
                        endGame.Defeat();
                    }
                    break;
            }
        }
    }
}
