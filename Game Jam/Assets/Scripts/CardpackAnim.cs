using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardpackAnim : MonoBehaviour
{
    public Animator anim;

    public void Enteranimation1() 
    {
        anim.SetTrigger("Enter1");
    }
    public void Enteranimation2() 
    {
        anim.SetTrigger("Enter2");
    }
}
