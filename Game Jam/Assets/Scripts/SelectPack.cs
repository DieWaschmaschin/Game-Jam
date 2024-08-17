using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using TMPro;
using Unity.VisualScripting;

public class SelectPack : MonoBehaviour
{
    static public bool selected;

    private Vector3 normSize;
    public float sizeChanger;
    private Vector3 biggerSize;

    public string type;

    public List<Cardpack> cardpacks = new List<Cardpack>();
    private Cardpack cardpack;

    public SpriteRenderer rend;
    public TextMeshPro text;

    [SerializeField]
    private HandCards _handCards;

    private void Start() 
    {
        selected = false;

        normSize = transform.localScale;
        biggerSize = normSize * sizeChanger;


        cardpack = cardpacks.Where(obj => obj.name == type).SingleOrDefault();
        rend.sprite = cardpack.artwork;
        text.text = cardpack.name;
    }

    void OnMouseOver()
    {
        transform.localScale = biggerSize;

        if(Input.GetButton("Left"))
        {
            var cards = cardpack.InstantiateCardPack();
            _handCards.Add(cards);
            transform.localScale = normSize;
            GetComponent<GiveCards>().type = type;
            GetComponent<GiveCards>().PackChoosen();
            selected = true;
        }
    }
    void OnMouseExit()
    {
        transform.localScale = normSize;
    }

    void Update()
    {
        if(selected == true)
        {
            Destroy(gameObject);
        }
    }

}
