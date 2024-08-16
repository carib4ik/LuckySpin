using System;
using UnityEngine;

public class CardsAnimationEventHandler : MonoBehaviour
{ 
    public event Action CardAnimationEnd;
    // public event Action AnimationStart;
    
    private static readonly int Show = Animator.StringToHash("show");

    public void PlayAnimation()
    {
        // AnimationStart?.Invoke();
        gameObject.SetActive(true);
    }

    private void OnAnimationEnd()
    {
        CardAnimationEnd?.Invoke();
        gameObject.SetActive(false);
    }
}
