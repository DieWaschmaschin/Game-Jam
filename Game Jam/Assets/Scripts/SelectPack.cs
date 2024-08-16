using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectPack : MonoBehaviour
{
    static public bool selected;

    private void Start() 
    {
        selected = false;
    }

    void OnMouseOver()
    {
        if(Input.GetButton("Left"))
        {
            GetComponent<GiveCards>().PackChoosen();
            selected = true;
        }
    }

    void Update()
    {
        if(selected == true)
        {
            Destroy(gameObject);
        }
    }

}
