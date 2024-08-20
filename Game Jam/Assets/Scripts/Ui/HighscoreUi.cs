using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HighscoreUi : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _highscoreText;
    public void Fix()
    {
        _highscoreText.text = $"Your highest population was {GameManager.Instance.Highscore:F0}";
    }
}
