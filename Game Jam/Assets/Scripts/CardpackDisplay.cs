using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CardpackDisplay : MonoBehaviour
{
    public Cardpack cardpack;

    public SpriteRenderer artworkImage;
    public TextMeshPro nameText;

    void Start()
    {
        nameText.text = cardpack.name;

        artworkImage.sprite = cardpack.artwork;
    }
}
