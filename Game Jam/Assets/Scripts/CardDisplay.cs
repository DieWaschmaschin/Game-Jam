using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CardDisplay : MonoBehaviour
{
    public List<Card> cards = new List<Card>();
    private Card card;
    private bool scaleCard;

    public SpriteRenderer artworkImage;
    public TextMeshPro nameText;

    public TextMeshPro weightText;

    void Start()
    {
        card = cards[Random.Range(0, cards.Count)];
        scaleCard = card.scaleCard;

        nameText.text = card.name;
        artworkImage.sprite = card.artwork;
        if(scaleCard == false)
        {
            weightText.text = card.weight.ToString();
        }
    }

    void OnMouseOver()
    {
        if(Input.GetButton("Left"))
        {
            GiveCardpacks.decksize -= 1;
            card.Print();
            Destroy(gameObject);
        }

    }
}
