using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Cardpack", menuName = "Cardpack")]
public class Cardpack : ScriptableObject 
{
    public Sprite artwork;
    
    public new string name; 
}
