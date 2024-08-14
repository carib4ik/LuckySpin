using UnityEngine;

public class AnimationEventHandler : MonoBehaviour
{
    private void OnAnimationEnd()
    {
        Destroy(gameObject);
    }
}