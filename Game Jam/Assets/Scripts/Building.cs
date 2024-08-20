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

    public void AddStats()
    {
        GameManager.Instance.population += population;
        GameManager.Instance.food += food;
        GameManager.Instance.entertainment += entertainment;
    }

    void Update()
    {
        if(Vector3.Angle(Vector3.up, transform.up) >= brokenAngle && broken == false && off == false)
        {
            Debug.Log("Broken");
            GameManager.Instance.population -= population;
            GameManager.Instance.food -= food;
            GameManager.Instance.entertainment -= entertainment;
            broken = true;
        }
        if(Vector3.Angle(Vector3.up, transform.up) <= brokenAngle && broken == true && off == false)
        {
            Debug.Log("Repaired");
            GameManager.Instance.population += population;
            GameManager.Instance.food += food;
            GameManager.Instance.entertainment += entertainment;
            broken = false;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "OffScale")
        {
            if(broken == false)
            {
                GameManager.Instance.population -= population;
                GameManager.Instance.food -= food;
                GameManager.Instance.entertainment -= entertainment;
            }
            GameManager.Instance.happiness -= 10;
            off = true;
        }
    }

    public bool Scale(CardType type, float scaleValue)
    {
        if(off)
        {
            return false;
        }
        Vector3 scale = transform.localScale;
        switch (type)
        {
            case CardType.ScaleHeight:
                scale.y *= 1 + scaleValue / 100f;
                break;
            case CardType.ScaleWidth:
                scale.x *= 1 + scaleValue / 100f;
                break;
            default:
                throw new NotImplementedException();
        }
        transform.localScale = scale;
        return true;
    }
}
