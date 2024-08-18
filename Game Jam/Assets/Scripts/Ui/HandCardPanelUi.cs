using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandCardPanelUi : MonoBehaviour
{
    [SerializeField]
    private GameObject _handCardPrefab;
    [SerializeField]
    private HandCards _handCards;
    [SerializeField]
    private List<HandCardUi> _handCardsUi = new List<HandCardUi>();

    private void OnEnable()
    {
        if(_handCards != null)
        {
            _handCards.OnHandCardsChanged += InstantiateCardUi;
        }
    }

    private void OnDisable()
    {
        if (_handCards != null)
        {
            _handCards.OnHandCardsChanged -= InstantiateCardUi;
        }
    }

    /// <summary>
    /// Deletes all cards, then creates new ones
    /// @todo: add object pooling
    /// </summary>
    private void InstantiateCardUi()
    {
        foreach (HandCardUi handCardUi in _handCardsUi)
        {
            Destroy(handCardUi.gameObject);
        }
        _handCardsUi.Clear();
        foreach (Card card in _handCards.CurrentCards)
        {
            HandCardUi ui = Instantiate(_handCardPrefab, transform)
                .GetComponent<HandCardUi>()
                .SetUp(card, this);
            _handCardsUi.Add(ui);
        }
    }

    public void Remove(Card card)
    {
        Debug.Log($"Removing {card.name}");
        _handCards.Remove(card);
    }
}
