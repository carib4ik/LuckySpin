using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class DrumController : MonoBehaviour
{
    public event Action RotationEnd;
    public event Action RotationStart;
    
    [SerializeField] private float _minSpeed = 200f; // Минимальная начальная скорость
    [SerializeField] private float _maxSpeed = 1000f; // Максимальная начальная скорость
    [SerializeField] private float _minDuration = 0.3f; // Минимальная длительность вращения
    [SerializeField] private float _maxDuration = 2f; // Максимальная длительность вращения

    private RectTransform _drum;
    private float _currentSpeed; // Текущая скорость вращения
    private float _duration; // Длительность вращения
    private bool _isSpinning; // Флаг вращения
    private float _elapsedTime = 0f; // Время прошедшее с начала вращения

    private void Awake()
    {
        _drum = GetComponent<RectTransform>();
    }

    private void Update()
    {
        if (_isSpinning)
        {
            _elapsedTime += Time.deltaTime;
            var t = _elapsedTime / _duration; // Нормализированное время (от 0 до 1)

            // Линейное уменьшение скорости
            _currentSpeed = Mathf.Lerp(_currentSpeed, 0, t);
            
            // Вращаем колесо
            _drum.Rotate(0, 0, _currentSpeed * Time.deltaTime);

            if (_elapsedTime >= _duration)
            {
                _isSpinning = false;
                _elapsedTime = 0f;
            }
        }
    }
    
    public void RotateDrum()
    {
        if (!_isSpinning)
        {
            _currentSpeed = Random.Range(_minSpeed, _maxSpeed);
            _duration = Random.Range(_minDuration, _maxDuration);
            _isSpinning = true;
        }
    }
}