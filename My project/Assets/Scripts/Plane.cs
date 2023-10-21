using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plane : MonoBehaviour
{
    public bool occupied = false;
    public GameObject cubePrefab; // Prefab dla kostki
    public GameObject Cards;
    public GameObject GameBoard;
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
        if (cubePrefab != null && occupied == false && Cards.GetComponent<Cards>().CardChoosen == true)
        {
            // Oblicz pozycj� docelow� dla kostki na podstawie �rodka obiektu
            Vector3 objectCenter = transform.position;
            Vector3 cubePosition = new Vector3(objectCenter.x, cubePrefab.transform.position.y, objectCenter.z);

            // Tworzenie nowej kostki na obliczonej pozycji
            Instantiate(cubePrefab, cubePosition, Quaternion.identity);
            occupied = true;
            Cards.GetComponent<Cards>().RandomCards();
            //this.GetComponent<SpriteRenderer>().sprite = Cards.GetComponent<Cards>().CardChoosenName;
        }
    }
}
