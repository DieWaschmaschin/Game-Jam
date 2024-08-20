using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance => _instance;

    public float population;
    public float food;
    private float foodPerRound;
    private float hungry;
    private float starving;
    
    public float entertainment ;
    public float happiness;

    public bool newPack;

    private void Awake()
    {
        if(_instance == null)
        {
            _instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public bool Build(Card card, Vector3 buildPosition)
    {
        buildPosition.z = -Camera.main.transform.position.z;
        Vector3 position = Camera.main.ScreenToWorldPoint(buildPosition);
        position.z = 0f;
        Instantiate(card.objectToSpawn, position, Quaternion.identity)
            .GetComponent<Building>()
            .AddStats();
        return true;
    }

    private void Update() 
    {
        if(newPack == true)
        {
            if(population > foodPerRound)
            {



                hungry = population - foodPerRound;
                Debug.Log("Hungry: " + hungry);
            }

            
            newPack = false;
        }
    }
}
