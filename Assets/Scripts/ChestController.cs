using System;
using UnityEngine;
using UnityEngine.UI;

public class ChestController : MonoBehaviour
{
    public event Action StartChestMovingAnimation;
    
    [SerializeField] private Button _claimButton;
    [SerializeField] private GameObject _coinsScore;
    
    private Animator _chestAnimator;
    private Button _chestButton;
    private bool _isEnd;
    
    private static readonly int GetPrize = Animator.StringToHash("getPrize");
    private static readonly int Result = Animator.StringToHash("showResult");
    private static readonly int Shake = Animator.StringToHash("shake");
    private static readonly int Hide = Animator.StringToHash("hide");

    private void Awake()
    {
        _chestAnimator = GetComponent<Animator>();
        _chestButton = GetComponent<Button>();
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
        _chestButton.interactable = true;
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
        _chestButton.interactable = false;
        _claimButton.gameObject.SetActive(true);
        _coinsScore.SetActive(true);
    }

    public void HideChest()
    {
        _chestAnimator.SetTrigger(Hide);
    }
    
}
