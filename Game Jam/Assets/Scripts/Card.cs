using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "Card")]
public class Card : ScriptableObject
{
    public Sprite artwork;

    public new string name;
    public float weight;

    public int population;
    public int food;
    public int entertainment;

    public bool scaleCard;
    public bool specialAbility;

    public void Print()
    {
        if(scaleCard == true)
        {
            Debug.Log(name);
        }
        else
        {
            Debug.Log(name + ": Weight: " + weight + " Population: " + population + " Food: " + food + " Entertainment: " + entertainment + " Special ability: " + specialAbility);
        }
    }
}
