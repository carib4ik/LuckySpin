using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private ButtonController _buttonController;
    [SerializeField] private DrumController _drumController;
    [SerializeField] private BadgeController _badgeController;
    [SerializeField] private PrizeController _prizeController;
    [SerializeField] private ChestController _chestController;
    [SerializeField] private DimmerController _dimmerController;

    [SerializeField] private CardsAnimationEventHandler[] _cardsAnimationEventHandlers;

    private void Start()
    {
        _drumController.DrumRotationEnd += _prizeController.ShowPrizeCard;
        _drumController.DrumRotationEnd += _dimmerController.Darken;
        _badgeController.BadgesEmpty += _buttonController.DisableButton;
        _badgeController.BadgesEmpty += _chestController.SetEnd;
        
        _chestController.StartChestMovingAnimation += _dimmerController.Darken;

        foreach (var card in _cardsAnimationEventHandlers)
        {
            card.CardAnimationEnd += _chestController.AnimateChest;
            card.CardAnimationEnd += _dimmerController.Lighten;
        }
    }

    public void QuitGame()
    {
        UnityEditor.EditorApplication.isPlaying = false;
    }
}