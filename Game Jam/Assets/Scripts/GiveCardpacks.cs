using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiveCardpacks : MonoBehaviour
{
    [SerializeField]
    private Cardpack _firstCardpack;

    [SerializeField]
    private HandCards _handCards;

    [SerializeField]
    private CardPackDecision _currentCardpacks;

    [SerializeField]
    private List<Cardpack> _cardpacks = new List<Cardpack>();

    private void Start()
    {
        HandOutFirstCardPack();
    }

    private void HandOutFirstCardPack()
    {
        if (_handCards == null)
        {
            Debug.LogError("No hand cards set");
            return;
        }
        var cards = _firstCardpack.InstantiateCardPack();
        _handCards.Add(cards);
    }

    private void OnEnable()
    {
        if (_handCards != null)
        {
            _handCards.OnHandCardsChanged += PresentCardpacks;
        }
    }

    private void OnDisable()
    {
        if (_handCards != null)
        {
            _handCards.OnHandCardsChanged -= PresentCardpacks;
        }
    }

    private void PresentCardpacks()
    {
        if(_handCards.CurrentCards.Count != 0)
        {
            _currentCardpacks.Unset();
            return;
        }

        List<Cardpack> newCardpacks = new List<Cardpack>();
        newCardpacks.AddRange(_cardpacks);

        //spawn two random cardpacks from our selection
        Cardpack lhs = newCardpacks[Random.Range(0, newCardpacks.Count)];
        newCardpacks.Remove(lhs);
        Cardpack rhs = newCardpacks[Random.Range(0, newCardpacks.Count)];
        _currentCardpacks.Set(lhs, rhs);
    }
}
