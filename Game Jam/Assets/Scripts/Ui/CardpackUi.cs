using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CardpackUi : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    [SerializeField]
    private Image _artwork;
    [SerializeField]
    private TextMeshProUGUI _name;

    private Cardpack _cardpack;

    [SerializeField]
    private HandCards _handCards;

    public void Set(Cardpack cardpack)
    {
        _cardpack = cardpack;
        _artwork.sprite = cardpack.artwork;
        _name.text = cardpack.name;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        transform.localScale = Vector3.one * 1.2f;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        transform.localScale = Vector3.one;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        var cards = _cardpack.InstantiateCardPack();
        _handCards.Add(cards);
    }
}
