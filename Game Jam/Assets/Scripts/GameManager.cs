using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance => _instance;

    public float population;
    public float food;

    [SerializeField]
    /// <summary>
    /// How many people are hungry
    /// </summary>
    private float _hungry;

    public float entertainment;
    public float happiness;

    public bool newPack;

    public UnityEvent OnNewPack;
    public UnityEvent OnBuild;
    public UnityEvent OnEndGame;

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
            Instantiate(card.objectToSpawn, position, Quaternion.identity, transform)
                .GetComponent<Building>()
                .AddStats();
            OnBuild?.Invoke();
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
                    bool success = building.Scale(card.cardType, card.scale);
                    if (success)
                    {
                        OnBuild?.Invoke();
                    }
                    return success;
                }
            }
        }
        return false;
    }

    private void Update()
    {
        if(newPack == true)
        {
            OnNewPack?.Invoke();

            float foodThisRound = food;
            if(_hungry <= foodThisRound)
            {
                foodThisRound -= _hungry;
                _hungry = 0;
            }
            else
            {
                _hungry -= foodThisRound;
                population -= _hungry;
                foodThisRound = 0;
            }

            if(population > foodThisRound)
            {
                _hungry = population - foodThisRound;
            }

            newPack = false;
        }
    }
}
