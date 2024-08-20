using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bowl : MonoBehaviour
{
    [SerializeField]
    private Scale _parent;

    [SerializeField]
    private float _multiplicator = 1f;

    [SerializeField]
    private List<Building> _buildings = new List<Building>();

    public void AddWeight(Building building)
    {
        if(!_buildings.Contains(building))
        {
            _buildings.Add(building);
            _parent.AddWeight(building.weight * _multiplicator);
        }
    }

    public void RemoveWeight(Building building)
    {
        _buildings.Remove(building);
        _parent.AddWeight(building.weight *_multiplicator * -1f);
    }
}
