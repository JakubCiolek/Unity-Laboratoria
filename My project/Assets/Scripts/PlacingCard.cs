using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacingCard : MonoBehaviour
{
    // Start is called before the first frame update

    public string[,] planeMatrix = {
            {"none", "none"},
            {"none", "none"}
        };
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

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
}
