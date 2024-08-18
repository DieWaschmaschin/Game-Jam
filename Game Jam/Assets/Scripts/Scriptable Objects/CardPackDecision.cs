using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class CardPackDecision : ScriptableObject
{
    public Cardpack Lhs;
    public Cardpack Rhs;

    public delegate void OnCardpackDecisionHandler();
    public OnCardpackDecisionHandler OnCardpackDecision;

    public void Set(Cardpack lhs, Cardpack rhs)
    {
        Lhs = lhs;
        Rhs = rhs;
        OnCardpackDecision?.Invoke();
    }

    public void Unset()
    {
        Lhs = null;
        Rhs = null;
        OnCardpackDecision?.Invoke();
    }
}
