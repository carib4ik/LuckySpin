using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
    [SerializeField] private PrizeController _prizeController;
    [SerializeField] private TextMeshProUGUI _coins;
    [SerializeField] private TextMeshProUGUI _gems;
    [SerializeField] private TextMeshProUGUI[] _score;

    private int _collectedCoins;
    private int _collectedGems;
    
    public void CalculateScore()
    {
        var prizes = _prizeController.GetCollectedPrizes();

        if (prizes.ContainsKey("CoinsPrizeCard"))
        {
            _collectedCoins = prizes["CoinsPrizeCard"] * 50;
            _score[0].text = "x" + _collectedCoins;
        }
        if (prizes.ContainsKey("GemsPrizeCard"))
        {
            _collectedGems = prizes["GemsPrizeCard"] * 2;
            _score[1].text = "x" + _collectedGems;
        }
        if (prizes.ContainsKey("HeartsPrizeCard"))
        {
            _score[2].text = "x" + prizes["HeartsPrizeCard"];
        }
        if (prizes.ContainsKey("RelicPrizeCard"))
        {
            _score[3].text = "x" + prizes["RelicPrizeCard"];
        }
    }

    public void SetStatusBarScore()
    {
        StartCoroutine(ChangeTextValue(_coins, _collectedCoins));
        StartCoroutine(ChangeTextValue(_gems, _collectedGems));
    }

    private IEnumerator ChangeTextValue(TextMeshProUGUI textMeshPro, int valueToAdd)
    {
        var startValue = Convert.ToInt32(textMeshPro.text);
        var targetValue = startValue + valueToAdd;
        var elapsedTime = 0f;

        while (elapsedTime < 1f)
        {
            elapsedTime += Time.deltaTime;
            var t = elapsedTime / 1f;
            var newValue = (int) Mathf.Lerp(startValue, targetValue, t);
            textMeshPro.text = newValue.ToString();
            yield return null;
        }

        textMeshPro.text = targetValue.ToString(); // Убедитесь, что конечное значение установлено точно
    }
}
