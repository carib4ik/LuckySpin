using System;
using UnityEngine;
using UnityEngine.UI;

public class ChestController : MonoBehaviour
{
    public event Action StartChestMovingAnimation;
    
    private Animator _chestAnimator;
    private Button _button;
    private bool _isEnd;
    
    private static readonly int GetPrize = Animator.StringToHash("getPrize");
    private static readonly int Result = Animator.StringToHash("showResult");
    private static readonly int Shake = Animator.StringToHash("shake");

    private void Awake()
    {
        _chestAnimator = GetComponent<Animator>();
        _button = GetComponent<Button>();
    }

    public void AnimateChest()
    {
        if (_isEnd)
        {
            PulseOnce();
            transform.parent.SetAsLastSibling();
            StartChestMovingAnimation?.Invoke();
            ShakeChest();
        }
        else
        {
            PulseOnce();
        }
    }

    private void ShakeChest()
    {
        _chestAnimator.SetTrigger(Shake);
        _button.interactable = true;
    }

    private void PulseOnce()
    {
        _chestAnimator.SetTrigger(GetPrize);
    }
    
    public void SetEnd()
    {
        _isEnd = true;
    }

    public void ShowCollectedPrizes()
    {
        _chestAnimator.SetTrigger(Result);
        _button.interactable = false;
    }
    
}
