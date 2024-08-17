using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiveCards : MonoBehaviour
{
    public GameObject card;
    public string type;
    
    public Vector3 deckPos1;
    public Vector3 deckPos2;
    public Vector3 deckPos3;
    public Vector3 deckPos4;
    public Vector3 deckPos5;
    
    public void PackChoosen()
    {
        GameObject card1 = Instantiate(card, deckPos1, Quaternion.identity);
        card1.GetComponent<CardDisplay>().type = type;
        GameObject card2 = Instantiate(card, deckPos2, Quaternion.identity);
        card2.GetComponent<CardDisplay>().type = type;
        GameObject card3 = Instantiate(card, deckPos3, Quaternion.identity);
        card3.GetComponent<CardDisplay>().type = type;
        GameObject card4 = Instantiate(card, deckPos4, Quaternion.identity);
        card4.GetComponent<CardDisplay>().type = "scale";
        GameObject card5 = Instantiate(card, deckPos5, Quaternion.identity);
        card5.GetComponent<CardDisplay>().type = "scale";
    }

}
