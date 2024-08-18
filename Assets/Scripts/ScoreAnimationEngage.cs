using UnityEngine;
using UnityEngine.UI;

public class ScoreAnimationEngage : MonoBehaviour
{
    [SerializeField] private GameObject _nextScoreGameObject;

    public void Engage()
    {
        _nextScoreGameObject.SetActive(true);
    }

    public void ActivateClaimButton()
    {
        _nextScoreGameObject.GetComponent<Button>().interactable = true;
    }
}
