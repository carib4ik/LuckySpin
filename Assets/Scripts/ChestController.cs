using UnityEngine;

public class ChestController : MonoBehaviour
{
    private Animator _chestAnimator;
    
    private static readonly int Prize = Animator.StringToHash("getPrize");

    private void Awake()
    {
        _chestAnimator = GetComponent<Animator>();
    }

    public void GetPrize()
    {
        _chestAnimator.SetTrigger(Prize);
    }
}
