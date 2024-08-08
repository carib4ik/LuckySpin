using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BadgeController : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private GameObject _badgePrefab;
    [SerializeField] private TextMeshProUGUI _textMeshPro;
    [SerializeField] private int _badgeQuantity;

    private GameObject _currentBudge;
    private Animator _badgeAnimator;
    
    private static readonly int Fly = Animator.StringToHash("fly");
    
    private void Awake()
    {
        _textMeshPro.text = "x" + _badgeQuantity;
        
        if (_badgeQuantity > 0)
        {
            CreateNewBadge();
        }
        
    }

    public void SpendBadge()
    {
        if (_badgeQuantity > 0)
        {
            CreateNewBadge();
            _badgeAnimator.SetTrigger(Fly);
            _badgeQuantity--;
            _textMeshPro.text = "x" + _badgeQuantity;
        }
        
        if (_badgeQuantity == 0)
        {
            _button.interactable = false;
        }
    }

    private void CreateNewBadge()
    {
        _currentBudge = Instantiate(_badgePrefab, transform);
        _badgeAnimator = _currentBudge.GetComponent<Animator>();
    }
}
