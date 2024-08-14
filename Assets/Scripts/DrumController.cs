using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class DrumController : MonoBehaviour
{
    public event Action RotationEnd;
    public event Action RotationStart;
    
    [SerializeField] private float minSpinDuration = 0.3f;
    [SerializeField] private float maxSpinDuration = 1.5f;
    
    private Animator _spinnerAnimator;
    private bool _isSpinning;
    private static readonly int IsSpinning = Animator.StringToHash("isSpinning");

    private void Start()
    {
        _spinnerAnimator = GetComponent<Animator>();
    }

    public void RotateDrum()
    {
        // var rotationTime = Random.Range(30, 100) / 100f;
        // _spinnerAnimator.Play("SpinDrum", 0, rotationTime);
        if (!_isSpinning)
        {
            StartCoroutine(SpinCoroutine());
        }
    }
    
    private IEnumerator SpinCoroutine()
    {
        // RotationStart!.Invoke();
        
        _isSpinning = true;
        _spinnerAnimator.SetBool(IsSpinning, true);
        
        var spinDuration = Random.Range(minSpinDuration, maxSpinDuration);
        yield return new WaitForSeconds(spinDuration);

        _spinnerAnimator.SetBool(IsSpinning, false);
        _isSpinning = false;

        yield return new WaitForSeconds(1f);

        RotationEnd!.Invoke();
    }
}