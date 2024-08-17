using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CardDisplay : MonoBehaviour
{
    public List<Card> fun = new List<Card>();
    public List<Card> food = new List<Card>();
    public List<Card> housing = new List<Card>();
    public List<Card> scale = new List<Card>();
    private List<Card> cards = new List<Card>();
    private Card card;
    private bool scaleCard = false;

    public SpriteRenderer artworkImage;
    public TextMeshPro nameText;

    public TextMeshPro weightText;

    private Vector3 normSize;
    public float sizeChanger;
    private Vector3 biggerSize;

    public string type;

    void Start()
    {
        if(type == "fun")
        {
            cards.AddRange(fun);
        }
        else if(type == "food")
        {
            cards.AddRange(food);
        }
        else if(type == "housing")
        {
            cards.AddRange(housing);
        }
        else if(type == "scale")
        {
            cards.AddRange(scale);
            scaleCard = true;
        }

        card = cards[Random.Range(0, cards.Count)];
        nameText.text = card.name;
        artworkImage.sprite = card.artwork;

        if(scaleCard == false)
        {
            weightText.text = card.weight.ToString();
        }
        else
        {
            weightText.enabled = false;
        }

        normSize = transform.localScale;
        biggerSize = normSize * sizeChanger;
    }

    void OnMouseOver()
    {
        transform.localScale = biggerSize;

        if(Input.GetButton("Left"))
        {
            transform.localScale = normSize;
            GiveCardpacks.decksize -= 1;
            card.Print();
            Destroy(gameObject);
        }

    }
    void OnMouseExit()
    {
        transform.localScale = normSize;   
    }
}
