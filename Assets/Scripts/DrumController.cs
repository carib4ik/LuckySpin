using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class DrumController : MonoBehaviour
{
    public event Action DrumRotationEnd;
    // public event Action DrumRotationStart;
    
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
    private AudioSource _audioSource;

    private void Awake()
    {
        _drum = GetComponent<RectTransform>();
        _audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (_isSpinning)
        {
            _elapsedTime += Time.deltaTime;
            var t = _elapsedTime / _duration;

            _currentSpeed = _initialSpeed * Mathf.Exp(-3 * t);
            
            _audioSource.pitch = Mathf.Lerp(1f, 0.1f, t);
            
            _drum.Rotate(0, 0, -_currentSpeed * Time.deltaTime);
            
            if (_elapsedTime >= _duration)
            {
                _isSpinning = false;
                _elapsedTime = 0f;
                _currentSpeed = 0f;
                
                _audioSource.pitch = 1f;
                _audioSource.Stop();
                
                DrumRotationEnd?.Invoke();
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
            
            _audioSource.Play();
        }
    }
}