using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Scale : MonoBehaviour
{
    [SerializeField]
    private Transform _arm;
    [SerializeField]
    private Transform _leftBowl;
    [SerializeField]
    private Transform _rightBowl;
    [SerializeField]
    private float _radius;
    [SerializeField]
    private Vector3 _bowlOffset;

    [SerializeField]
    private List<Rigidbody> _bodies = new List<Rigidbody>();
    [SerializeField]
    private float _explosionForce = 100f;
    [SerializeField]
    private float _explosionRadius = 10f;

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
    private float _timeScale = 1.0f;

    [SerializeField]
    private AnimationCurve _curve;

    public UnityEvent OnEndGame;

    private void Start()
    {
        _t = 1f;
        PositionArmAndBowls();
    }

    public void AddWeight(float weight)
    {
        _previousWeight = _currentWeight;
        _currentWeight += weight;
        _t = 0f;

        if(_currentWeight < _weightRange.x || _currentWeight > _weightRange.y)
        {
            EndGame();
        }
    }

    private void EndGame()
    {
        foreach (var b in _bodies)
        {
            b.isKinematic = false;
            b.AddExplosionForce(_explosionForce, Vector3.forward, _explosionRadius);
        }
        OnEndGame?.Invoke();
        enabled = false;
    }

    private void Update()
    {
        if(_t >= 1.0f)
        {
            return;
        }

        PositionArmAndBowls();
    }

    private void PositionArmAndBowls()
    {
        _t += Time.deltaTime * _timeScale;
        float lerpedWeight = Mathf.Lerp(_previousWeight, _currentWeight, _t);
        //this assumes that weight is symmetric around 0f
        float normalizedLerpedWeight = lerpedWeight / _weightRange.y;
        float jitter = _curve.Evaluate(_t);
        if (_currentWeight < _previousWeight)
        {
            jitter *= -1f;
        }
        float angle = normalizedLerpedWeight * _scaleAmplitude + jitter;

        _arm.rotation = Quaternion.Euler(0f, 0f, angle);
        float x = Mathf.Cos(angle * Mathf.Deg2Rad) * _radius;
        float y = Mathf.Sin(angle * Mathf.Deg2Rad) * _radius;
        _leftBowl.position = new Vector3(x, y, 0f) + _bowlOffset;
        _rightBowl.position = new Vector3(-x, -y, 0f) + _bowlOffset;
    }
}
