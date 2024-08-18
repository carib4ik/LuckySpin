using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PrizeController : MonoBehaviour
{
    [SerializeField] private CardsAnimationEventHandler[] _prizeCards;

    private bool _isEnd;
    private RectTransform _drum;
    private Dictionary<string, int> _collectedPrizes = new();

    private void Start()
    {
        _drum = GetComponent<RectTransform>();
    }

    public void ShowPrizeCard()
    {
        var sector = GetPrizeIndex();
        _prizeCards[sector].PlayAnimation();
        CollectPrize(sector);
    }

    private int GetPrizeIndex()
    {
        var currentRotation = _drum.eulerAngles.z + 22.5f;
        var prizeIndex = Mathf.FloorToInt(currentRotation / 45f);
        prizeIndex %= 8;

        return prizeIndex;
    }
    
    private void CollectPrize(int sector)
    {
        var prizeName = _prizeCards[sector].name;

        if (_collectedPrizes.ContainsKey(prizeName))
        {
            // Если приз уже существует, увеличиваем его количество
            _collectedPrizes[prizeName] += 1;
        }
        else
        {
            // Если приза нет в словаре, добавляем новый приз
            _collectedPrizes.Add(prizeName, 1);
        }
    }

    public Dictionary<string, int> GetCollectedPrizes()
    {
        return _collectedPrizes;
    }
}