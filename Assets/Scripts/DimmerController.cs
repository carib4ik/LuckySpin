using UnityEngine;

public class DimmerController : MonoBehaviour
{
    private Animator _animator;
    private static readonly int Darken1 = Animator.StringToHash("darken");
    private static readonly int Lighten1 = Animator.StringToHash("lighten");

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void Darken()
    {
        _animator.SetTrigger(Darken1);
    }
    
    public void Lighten()
    {
        _animator.SetTrigger(Lighten1);
    }
}
