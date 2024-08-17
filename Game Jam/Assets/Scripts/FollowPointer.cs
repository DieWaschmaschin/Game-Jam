using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPointer : MonoBehaviour
{
    [SerializeField]
    private PointerData _pointerData;
    [SerializeField]
    private MeshRenderer _meshRenderer;

    private void Start()
    {
        UpdatePointer();
    }

    private void OnEnable()
    {
        if( _pointerData != null )
        {
            _pointerData.OnPointerDataChanged += UpdatePointer;
        }
    }

    private void OnDisable()
    {
        if (_pointerData != null)
        {
            _pointerData.OnPointerDataChanged -= UpdatePointer;
        }
    }

    private void UpdatePointer()
    {
        _meshRenderer.enabled = _pointerData.IsEnabled;
        Vector3 pointerPosition = _pointerData.Position;
        pointerPosition.z = -Camera.main.transform.position.z;
        Vector3 position = Camera.main.ScreenToWorldPoint(pointerPosition);
        position.z = 0f;
        transform.position = position;
    }
}
