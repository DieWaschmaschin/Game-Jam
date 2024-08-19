using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public bool scaleCard;
    [SerializeField]
    private Vector2 scaleWidthRange;
    [SerializeField]
    private Vector2 scaleHeightRange;
    public float scaleWidth;
    public float scaleHeight;
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

    /// <summary>
    /// Collapses the randomness into instantiated values. Needs to be called for scale cards
    /// </summary>
    /// <returns></returns>
    public Card Collapse()
    {
        if (scaleCard)
        {
            bool width = Random.value > 0.5f;
            if (width)
            {
                float randomWidth = Random.value * scaleWidthRange.y + scaleWidthRange.x;
                randomWidth = Mathf.Round(randomWidth * 100);
                randomWidth /= 100;
                scaleWidth = randomWidth;
            }
            else
            {
                float randomHeight = Random.value * scaleHeightRange.y + scaleHeightRange.x;
                randomHeight = Mathf.Round(randomHeight * 100);
                randomHeight /= 100;
                scaleWidth = randomHeight;
            }
        }
        return this;
    }
}
