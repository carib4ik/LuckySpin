using UnityEngine;
using UnityEngine.UI;

public class DrumController : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private GameObject _prizeCard;
    
    private Animator _spinnerAnimator;
    
    private static readonly int Rotate = Animator.StringToHash("rotate");
    private static readonly int Stop = Animator.StringToHash("stop");

    private void Start()
    {
        _spinnerAnimator = GetComponent<Animator>();
    }

    public void RotateDrum()
    {
        var motionStop = Random.Range(20, 100) / 100f;
        // _animator.SetFloat(Stop, motionStop);

        _spinnerAnimator.SetTrigger(Rotate);
    }

    public void DisableButton()
    {
        _button.interactable = false;
    }
    
    public void ActivateButton()
    {
        _button.interactable = true;
    }

    public void ShowPrize()
    {
        Instantiate(_prizeCard, transform.parent);
    }
}