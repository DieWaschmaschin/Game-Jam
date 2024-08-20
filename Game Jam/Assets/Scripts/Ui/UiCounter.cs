using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UiCounter : MonoBehaviour
{
    public Text population;
    public Text food;
    public Text entertainment;

    public Slider slider;

    
    void Start()
    {
        
    }


    void Update()
    {
        population.text = $"Population: {GameManager.Instance.population:F0}";
        food.text = $"Food: {GameManager.Instance.food:F0} / {GameManager.Instance.population:F0}";
        entertainment.text = $"Entertainment: {GameManager.Instance.entertainment:F0} / {GameManager.Instance.population:F0}";

        slider.value = GameManager.Instance.happiness / 100;

    }
}
