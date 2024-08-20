using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance => _instance;

    public float population;
    public float food;
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
        if (card.cardType == CardType.Normal)
        {
            buildPosition.z = -Camera.main.transform.position.z;
            Vector3 position = Camera.main.ScreenToWorldPoint(buildPosition);
            position.z = 0f;
            Instantiate(card.objectToSpawn, position, Quaternion.identity)
                .GetComponent<Building>()
                .AddStats();
            return true;
        }
        else
        {
            Ray ray = Camera.main.ScreenPointToRay(buildPosition);
            if(Physics.Raycast(ray, out RaycastHit hitInfo))
            {
                Building building = hitInfo.collider.GetComponent<Building>();
                if(building != null)
                {
                    building.Scale(card.cardType, card.scale);
                    return true;
                }
            }
        }
        return false;
    }

    private void Update()
    {
        if(newPack == true)
        {
            if(population > food)
            {
                if(hungry - food > 0)
                {
                    starving = hungry - food;
                    hungry = population - food - starving;
                }
                else if(hungry - food == 0)
                {
                    starving = 0;
                    hungry = population;
                }
                else
                {
                    starving = 0;
                    hungry += population - food;
                    if(hungry < 0)
                    {
                        hungry = 0;
                    }
                }
                /*Debug.Log("Hungry: " + hungry);
                Debug.Log("Starving: " + starving);*/
            }

            newPack = false;
        }
    }
}
