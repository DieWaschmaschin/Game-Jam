using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardpackPanelUi : MonoBehaviour
{
    [SerializeField]
    private Canvas _canvas;

    [SerializeField]
    private CardPackDecision _currentCardpacks;

    [SerializeField]
    private CardpackUi _lhs;
    [SerializeField]
    private CardpackUi _rhs;

    private void OnEnable()
    {
        if( _currentCardpacks != null )
        {
            _currentCardpacks.OnCardpackDecision += EnableUi;
        }
    }

    private void OnDisable()
    {
        if (_currentCardpacks != null)
        {
            _currentCardpacks.OnCardpackDecision -= EnableUi;
        }
    }

    private void EnableUi()
    {
        if(_currentCardpacks.Lhs == null || _currentCardpacks.Rhs == null)
        {
            _canvas.enabled = false;
            return;
        }
       _canvas.enabled = true;
        _lhs.Set(_currentCardpacks.Lhs);
        _rhs.Set(_currentCardpacks.Rhs);
    }
}
