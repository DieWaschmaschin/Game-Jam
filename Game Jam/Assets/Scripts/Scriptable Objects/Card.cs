using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CardType
{
    Normal,
    ScaleHeight,
    ScaleWidth,
}

[CreateAssetMenu(fileName = "New Card", menuName = "Card")]
public class Card : ScriptableObject
{
    public GameObject objectToSpawn;
    public Sprite artwork;

    public new string name;
    public float weight;

    public int population;
    public int food;
    public int entertainment;

    public CardType cardType;
    [SerializeField]
    private Vector2 scaleRange;
    public float scale;
    public bool specialAbility;

    public void Print()
    {
        if(cardType != CardType.Normal)
        {
            Debug.Log(name);
        }
        else
        {
            Debug.Log(name + ": Weight: " + weight + " Population: " + population + " Food: " + food + " Entertainment: " + entertainment + " Special ability: " + specialAbility);
        }
    }

    /// <summary>
    /// Collapses the randomness into instantiated values. Needs to be called for scale cards
    /// </summary>
    /// <returns></returns>
    public Card Collapse()
    {
        if (cardType == CardType.Normal)
        {
            throw new System.ArgumentException("Only scale cards can be collapsed");
        }
        float randomWidth = Random.Range(scaleRange.x, scaleRange.y);
        randomWidth = Mathf.Round(randomWidth / 5);
        randomWidth *= 5;
        scale = Mathf.Round(randomWidth);
        return this;
    }
}
