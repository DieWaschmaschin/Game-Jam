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
        population.text = "Population: " + GameManager.Instance.population;
        food.text = "Food: " + GameManager.Instance.food + "/" + GameManager.Instance.population;
        entertainment.text = "Entertainment: " + GameManager.Instance.entertainment + "/" + GameManager.Instance.population;

        slider.value = GameManager.Instance.happiness / 100;

    }
}
