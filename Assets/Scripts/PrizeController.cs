using System.Collections.Generic;
using UnityEngine;

public class PrizeController : MonoBehaviour
{
    [SerializeField] private CardsAnimationEventHandler[] _prizeCards;
    
    private RectTransform _drum;
    private List<int> _collection = new();

    private void Start()
    {
        _drum = GetComponent<RectTransform>();
    }
    
    public void ShowPrize()
    {
        var sector = GetPrizeIndex();
        _prizeCards[sector].PlayAnimation();
        _collection.Add(sector);
    }
    
    private int GetPrizeIndex()
    {
        var currentRotation = _drum.eulerAngles.z + 22.5f;
        var prizeIndex = Mathf.FloorToInt(currentRotation / 45f);
        prizeIndex %= 8;
        
        return prizeIndex;
    }
}
