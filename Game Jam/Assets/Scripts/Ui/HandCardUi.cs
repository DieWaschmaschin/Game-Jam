using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class HandCardUi : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField]
    private Image _artwork;
    [SerializeField]
    private TextMeshProUGUI _name;
    [SerializeField]
    private TextMeshProUGUI _weight;

    [SerializeField]
    private PointerData _pointerData;

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
        SetCardSize(1.2f);
    }

    private void SetCardSize(float factor = 1.0f)
    {
        var recttransform = (RectTransform)transform;
        recttransform.sizeDelta = _originalSize * factor;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        SetCardSize();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        SetCardSize();
        _pointerData?.Set(true, eventData.position);
    }

    public void OnDrag(PointerEventData eventData)
    {
        _pointerData?.Set(true, eventData.position);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        _pointerData?.Set(false, eventData.position);
        // If we can build there, we build the building and remove the card
        if(build(eventData.position))
        {
            _parent.Remove(_card);
        }
    }

    /// <summary>
    /// @todo: implement - but this should not be here, maybe a building manager?
    /// </summary>
    /// <returns></returns>
    private bool build(Vector3 buildPosition)
    {
        buildPosition.z = -Camera.main.transform.position.z;
        Vector3 position = Camera.main.ScreenToWorldPoint(buildPosition);
        position.z = 0f;
        Instantiate(_card.objectToSpawn, position, Quaternion.identity);
        return true;
    }
}
