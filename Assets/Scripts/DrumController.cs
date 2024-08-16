using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class DrumController : MonoBehaviour
{
    public event Action RotationEnd;
    public event Action RotationStart;
    
    [SerializeField] private float _minSpeed;
    [SerializeField] private float _maxSpeed;
    [SerializeField] private float _minDuration;
    [SerializeField] private float _maxDuration;

    private RectTransform _drum;
    private float _currentSpeed;
    private float _duration; 
    private bool _isSpinning; 
    private float _elapsedTime;
    private float _initialSpeed;

    private void Awake()
    {
        _drum = GetComponent<RectTransform>();
    }

    private void Update()
    {
        if (_isSpinning)
        {
            _elapsedTime += Time.deltaTime;
            var t = _elapsedTime / _duration;

            _currentSpeed = _initialSpeed * Mathf.Exp(-3 * t);
            
            _drum.Rotate(0, 0, -_currentSpeed * Time.deltaTime);
            
            if (_elapsedTime >= _duration)
            {
                _isSpinning = false;
                _elapsedTime = 0f;
                _currentSpeed = 0f;
                
                RotationEnd?.Invoke();
            }
        }
    }
    
    public void RotateDrum()
    {
        if (!_isSpinning)
        {
            _initialSpeed = Random.Range(_minSpeed, _maxSpeed);
            _currentSpeed = _initialSpeed;
            _duration = Random.Range(_minDuration, _maxDuration);
            _isSpinning = true;
        }
    }
}