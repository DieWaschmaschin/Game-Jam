using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scale : MonoBehaviour
{
    [SerializeField]
    private float _currentWeight = 0f;
    private float _previousWeight = 0f;

    [SerializeField]
    private Vector2 _weightRange = new Vector2(-100.0f, 100.0f);
    [SerializeField]
    private float _scaleAmplitude = 44.0f;

    [SerializeField]
    private float _t = 1.0f;

    [SerializeField]
    private AnimationCurve _curve;

    public void AddWeight(float weight)
    {
        _previousWeight = _currentWeight;
        _currentWeight += weight;
        _t = 0f;

        if(_currentWeight < _weightRange.x || _currentWeight > _weightRange.y)
        {
            //end game
        }
    }

    private void Update()
    {
        if(_t >= 1.0f)
        {
            return;
        }

        _t += Time.deltaTime;
        float lerpedWeight = Mathf.Lerp(_previousWeight, _currentWeight, _t);
        //this assumes that weight is symmetric around 0f
        float normalizedLerpedWeight = lerpedWeight / _weightRange.y;
        float angle = normalizedLerpedWeight * _scaleAmplitude + _curve.Evaluate(_t);

        transform.rotation = Quaternion.Euler(0f, 0f, angle);
    }
}
