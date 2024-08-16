using UnityEngine;

public class ChestController : MonoBehaviour
{
    private Animator _chestAnimator;
    
    private static readonly int GetPrize = Animator.StringToHash("getPrize");
    private static readonly int Result = Animator.StringToHash("showResult");
    private bool _isEnd;

    private void Awake()
    {
        _chestAnimator = GetComponent<Animator>();
    }

    public void AnimateChest()
    {
        if (_isEnd)
        {
            PulseOnce();
            ShowResult();
        }
        else
        {
            PulseOnce();
        }
    }

    private void ShowResult()
    {
        _chestAnimator.SetTrigger(Result);
    }

    private void PulseOnce()
    {
        _chestAnimator.SetTrigger(GetPrize);
    }
    
    public void SetEnd()
    {
        _isEnd = true;
    }
}
