using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiveCardpacks : MonoBehaviour
{
    public Vector3 cardpackPos1;
    public Vector3 cardpackPos2;

    private GameObject cardpack1;
    private GameObject cardpack2;

    public List <GameObject> cardpacks = new List<GameObject>();
    private List <GameObject> newCardpacks = new List<GameObject>();
    
    static public int decksize = 0;

    void Update()
    {
        if(decksize == 0)
        {
            SelectNewCardpacks();
            SpawnCardpacks();
            decksize = 5;
        }
    }


    private void SelectNewCardpacks()
    {
        newCardpacks.AddRange(cardpacks);
        cardpack1 = newCardpacks[Random.Range(0, newCardpacks.Count)];
        newCardpacks.Remove(cardpack1);
        cardpack2 = newCardpacks[Random.Range(0, newCardpacks.Count)];
        newCardpacks.Clear();
    }

    private void SpawnCardpacks()
    {
        Instantiate(cardpack1, cardpackPos1, transform.rotation);
        Instantiate(cardpack2, cardpackPos2, transform.rotation);
    }
}
