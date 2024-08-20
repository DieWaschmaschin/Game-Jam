using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Cardpack", menuName = "Cardpack")]
public class Cardpack : ScriptableObject 
{
    public Sprite artwork;
    public new string name;

    public List<Card> PossibleCards = new List<Card>();
    public List<Card> AdditionalCards = new List<Card>();

    public List<Card> InstantiateCardPack()
    {
        List<Card> cards = new List<Card>();
        for (int i = 0; i < 3; i++)
        {
            Card randomCard = PossibleCards[Random.Range(0, PossibleCards.Count)];
            cards.Add(Instantiate(randomCard));
        }

        List<Card> additionalCards = new List<Card>();
        for (int i = 0; i < 2; i++)
        {
            Card randomCard = AdditionalCards[Random.Range(0, AdditionalCards.Count)];
            cards.Add(Instantiate(randomCard).Collapse());
        }
        return cards;
    }
}
