using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiveCards : MonoBehaviour
{
    public GameObject card;
    public GameObject scaleCard;
    
    public Vector3 deckPos1;
    public Vector3 deckPos2;
    public Vector3 deckPos3;
    public Vector3 deckPos4;
    public Vector3 deckPos5;
    
    public void PackChoosen()
    {
        Instantiate(card, deckPos1, Quaternion.identity);
        Instantiate(card, deckPos2, Quaternion.identity);
        Instantiate(card, deckPos3, Quaternion.identity);
        Instantiate(scaleCard, deckPos4, Quaternion.identity);
        Instantiate(scaleCard, deckPos5, Quaternion.identity);
    }

}
