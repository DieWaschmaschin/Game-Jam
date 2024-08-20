using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    public float weight;
    public float population;
    public float food;
    public float entertainment;

    public float brokenAngle;
    private bool broken = false;
    private bool off = false;

    private Bowl _bowl;
    private bool _isAdded = false;

    private void Start()
    {
        RaycastHit[] hits = Physics.RaycastAll(transform.position, Vector3.down);
        foreach (RaycastHit hit in hits)
        {
            Bowl bowl = hit.collider.GetComponent<Bowl>();
            if (bowl != null)
            {
                _bowl = bowl;
            }
        }
    }

    public void AddStats(Card card)
    {
        weight = card.weight;
        population = card.population;
        food = card.food;
        entertainment = card.entertainment;
        AddStats();
    }

    void Update()
    {
        if(Vector3.Angle(Vector3.up, transform.up) >= brokenAngle && broken == false && off == false)
        {
            Debug.Log("Broken");
            RemoveStats();
            broken = true;
        }
        if(Vector3.Angle(Vector3.up, transform.up) <= brokenAngle && broken == true && off == false)
        {
            Debug.Log("Repaired");
            AddStats();
            broken = false;
        }
    }

    private void AddStats()
    {
        GameManager.Instance.population += population;
        GameManager.Instance.food += food;
        GameManager.Instance.entertainment += entertainment;
    }

    private void RemoveStats()
    {
        GameManager.Instance.population -= population;
        GameManager.Instance.food -= food;
        GameManager.Instance.entertainment -= entertainment;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(!_isAdded)
        {
            _bowl?.AddWeight(this);
            _isAdded = true;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "OffScale")
        {
            if(broken == false)
            {
                GameManager.Instance.population -= population;
                GameManager.Instance.food -= food;
                GameManager.Instance.entertainment -= entertainment;
            }
            GameManager.Instance.happiness -= 10;
            off = true;
            _bowl?.RemoveWeight(this);
        }
    }

    public bool Scale(CardType type, float scaleValue)
    {
        if(off)
        {
            return false;
        }
        Vector3 scale = transform.localScale;
        float correctScale = 1 + scaleValue / 100f;
        switch (type)
        {
            case CardType.ScaleHeight:
                scale.y *= correctScale;
                break;
            case CardType.ScaleWidth:
                scale.x *= correctScale;
                break;
            default:
                throw new NotImplementedException();
        }
        RemoveStats();
        weight *= correctScale;
        population *= correctScale;
        food *= correctScale;
        entertainment *= correctScale;
        AddStats();
        _bowl?.UpdateWeight(this, correctScale);
        transform.localScale = scale;
        return true;
    }
}
