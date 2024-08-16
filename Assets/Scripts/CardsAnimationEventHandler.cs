using System;
using UnityEngine;

public class CardsAnimationEventHandler : MonoBehaviour
{ 
    public event Action AnimationEnd;
    
    private static readonly int Show = Animator.StringToHash("show");

    public void PlayAnimation()
    {
        gameObject.SetActive(true);
    }

    private void OnAnimationEnd()
    {
        AnimationEnd!.Invoke();
        gameObject.SetActive(false);
    }
}
