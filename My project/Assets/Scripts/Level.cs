using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.UI;

public class Level : MonoBehaviour
{
    public Button Easy;
    public Button Medium;
    public Button Hard;
    public Canvas startMenu;
    public Canvas Cards;
    public TMP_InputField inputNickname;

    public string nickname = "";
    public int choosenLevel = 0;
    // Start is called before the first frame update
    public void ChooseLevel(int level)
    {
        Easy.gameObject.GetComponent<Image>().color = Color.white;
        Medium.gameObject.GetComponent<Image>().color = Color.white;
        Hard.gameObject.GetComponent<Image>().color = Color.white;
        switch (level)
        {
            case 1:
                Easy.gameObject.GetComponent<Image>().color = Color.red;
                choosenLevel = 1;
                break;
            case 2:
                Medium.gameObject.GetComponent<Image>().color = Color.red;
                choosenLevel = 2;
                break;
            case 3:
                Hard.gameObject.GetComponent<Image>().color = Color.red;
                choosenLevel = 3;
                break;
            default:
                break;
        }
    }
    public void StartGame() {
        if (choosenLevel != 0 || nickname == "") {

            Debug.Log(nickname + choosenLevel);
            Cards.gameObject.SetActive(true);
            startMenu.gameObject.SetActive(false);
        }
    }
    public void NicknameValueChanged(string n) {

        nickname = inputNickname.text;
    }
    void Start()
    {
        Cards.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
