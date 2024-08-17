using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiveCardpacks : MonoBehaviour
{
    public Vector3 cardpackPos1;
    public Vector3 cardpackPos2;

    public GameObject cardpack;

    public List<string> types = new List<string>();
    private List <string> newTypes = new List<string>();
    
    static public int decksize = 0;

    void Update()
    {
        if(decksize == 0)
        {
            SelectNewCardpacks();
            decksize = 5;
        }
    }


    private void SelectNewCardpacks()
    {
        newTypes.AddRange(types);

        GameObject cardpack1 = Instantiate(cardpack, cardpackPos1, transform.rotation);
        cardpack1.GetComponent<SelectPack>().type = newTypes[Random.Range(0, newTypes.Count)];
        cardpack1.GetComponent<CardpackAnim>().Enteranimation1();

        newTypes.Remove(cardpack1.GetComponent<SelectPack>().type);
        GameObject cardpack2 = Instantiate(cardpack, cardpackPos2, transform.rotation);
        cardpack2.GetComponent<SelectPack>().type = newTypes[Random.Range(0, newTypes.Count)];
        cardpack2.GetComponent<CardpackAnim>().Enteranimation2();

        newTypes.Clear();
    }
}
