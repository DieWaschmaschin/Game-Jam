using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class HandCardUi : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    [SerializeField]
    private Image _artwork;
    [SerializeField]
    private TextMeshProUGUI _name;
    [SerializeField]
    private TextMeshProUGUI _weight;

    private Vector2 _originalSize;
    private Card _card;
    private HandCardPanelUi _parent;

    public HandCardUi SetUp(Card card, HandCardPanelUi parent)
    {
        _card = card;
        _parent = parent;
        _artwork.sprite = card.artwork;
        _name.text = card.name;
        if(card.scaleCard)
        {
            _weight.enabled = false;
        }
        else
        {
            _weight.enabled = true;
            _weight.text = $"{card.weight}";
        }
        _originalSize = ((RectTransform)transform).sizeDelta;
        return this;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        var recttransform = (RectTransform)transform;
        recttransform.sizeDelta = _originalSize * 1.2f;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        var recttransform = (RectTransform)transform;
        recttransform.sizeDelta = _originalSize;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        _parent.Remove(_card);
    }
}
