using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BadgeController : MonoBehaviour
{
    public event Action BadgesEmpty;
    
    [SerializeField] private GameObject _badgePrefab;
    [SerializeField] private TextMeshProUGUI _textMeshPro;
    [SerializeField] private int _badgeQuantity;

    private GameObject _currentBudge;
    private Animator _badgeAnimator;
    
    private static readonly int Fly = Animator.StringToHash("fly");
    
    private void Awake()
    {
        _textMeshPro.text = "x" + _badgeQuantity;
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
            BadgesEmpty!.Invoke();
        }
    }

    private void CreateNewBadge()
    {
        _currentBudge = Instantiate(_badgePrefab, transform);
        _badgeAnimator = _currentBudge.GetComponent<Animator>();
    }
}
