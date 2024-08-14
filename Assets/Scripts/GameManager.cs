using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private ButtonController _buttonController;
    [SerializeField] private DrumController _drumController;
    [SerializeField] private BadgeController _badgeController;
    [SerializeField] private PrizeController _prizeController;
    [SerializeField] private ChestController _chestController;
    [SerializeField] private CardsAnimationEventHandler[] _cardsAnimationEventHandlers;

    private void Start()
    {
        // _drumController.RotationStart += _buttonController.DisableButton;
        // _drumController.RotationEnd += _buttonController.ActivateButton;
        _drumController.RotationEnd += _prizeController.ShowPrize;
        _badgeController.BadgesEmpty += _buttonController.DisableButton;

        for (var i = 0; i < _cardsAnimationEventHandlers.Length; i++)
        {
            if (i == 2) continue;
            _cardsAnimationEventHandlers[i].AnimationEnd += _chestController.GetPrize;
        }
    }

    public void QuitGame()
    {
        UnityEditor.EditorApplication.isPlaying = false;
    }
    
}
