using UnityEngine;

public class ChestController : MonoBehaviour
{
    private Animator _chestAnimator;
    
    private static readonly int Prize = Animator.StringToHash("getPrize");
    private static readonly int Result = Animator.StringToHash("showResult");

    private void Awake()
    {
        _chestAnimator = GetComponent<Animator>();
    }

    public void GetPrize()
    {
        _chestAnimator.SetTrigger(Prize);
    }

    public void ShowResult()
    {
        transform.SetAsLastSibling();
        _chestAnimator.SetTrigger(Result);
    }
}
