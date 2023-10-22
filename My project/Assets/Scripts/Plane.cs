using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;

public class Plane : MonoBehaviour
{
    public bool occupied = false;
    public GameObject Cards;
    public GameObject GameBoard;
    public GameObject FireStation;
    public GameObject Hospital;
    public GameObject Market;
    public GameObject Police;
    public GameObject CardEmpty;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseDown()
    {
        if (occupied == false && Cards.GetComponent<Cards>().CardChoosen == true)
        {
            // Oblicz pozycj� docelow� dla kostki na podstawie �rodka obiektu
            Vector3 objectCenter = transform.position;
            //Vector3 cubePosition = new Vector3(objectCenter.x, cubePrefab.transform.position.y, objectCenter.z);

            // Tworzenie nowej kostki na obliczonej pozycji
            string card = Cards.GetComponent<Cards>().cardPick;
            string output = Regex.Replace(card, @"[\d-]", string.Empty);
            switch(output){
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

            GameObject newCard = Instantiate(CardEmpty, new Vector3(objectCenter.x, 0.1f, objectCenter.z), CardEmpty.transform.rotation);
            MeshRenderer meshRenderer = newCard.GetComponent<MeshRenderer>();
            meshRenderer.material = Resources.Load<Material>("CardTextures/Blue_PlayingCards_" + card + "_00");
            //Instantiate(cubePrefab, cubePosition, Quaternion.identity);
            occupied = true;
            Cards.GetComponent<Cards>().RandomCards();
            //this.GetComponent<SpriteRenderer>().sprite = Cards.GetComponent<Cards>().CardChoosenName;
            
        }
    }
}
