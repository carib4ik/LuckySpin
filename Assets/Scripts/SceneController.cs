using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public void LoadLuckyDrawScene()
    {
        SceneManager.LoadSceneAsync(SceneNames.LUCKY_DRAW);
    }
    
    public void LoadLobbyScene()
    {
        SceneManager.LoadSceneAsync(SceneNames.LOBBY);
    }
}
