using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    public float weight;
    public float population;
    public float food;
    public float entertainment;

    public void AddStats()
    {
        GameManager.Instance.population += population;
        GameManager.Instance.food += food;
        GameManager.Instance.entertainment += entertainment;
    }

    
    void Update()
    {
        
    }
}
