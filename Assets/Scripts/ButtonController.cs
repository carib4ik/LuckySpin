using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    private Button _button;
    
    private void Awake()
    {
        _button = GetComponent<Button>();
    }

    public void DisableButton()
    {
        _button.interactable = false;
    }
    
    public void ActivateButton()
    {
        _button.interactable = true;
    }
}
