using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class PointerData : ScriptableObject
{
    public Vector2 Position;
    public bool IsEnabled;

    public delegate void OnPointerDataChangedHandler();
    public OnPointerDataChangedHandler OnPointerDataChanged;

    public void Set(bool isEnabled, Vector2 position)
    {
        IsEnabled = isEnabled;
        Position = position;
        OnPointerDataChanged?.Invoke();
    }
}
