using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] bool isMainMenu = false;
    public void LoadNextScene()
    {
        if(isMainMenu)
        {
            Cursor.visible = false;            
        }
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void LoadStartScene()
    {
        SceneManager.LoadScene(0);
    }

    public void LoadBlueNaveGameplay()
    {
        SceneManager.LoadScene("NaveBlueGameplay");
        FindObjectOfType<GameSession>().ResetGame();
    }
    public void LoadCavernaGameplay()
    {
        SceneManager.LoadScene("CavernaGameplay");
        FindObjectOfType<GameSession>().ResetGame();
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    public void ComecaJogoBR()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void ComecaJogoEN()
    {
        SceneManager.LoadScene("MainMenuEN");
    }
    public void CinematicaEN()
    {
        Cursor.visible = false;
        SceneManager.LoadScene("Cinematics IntroEN");
    }
}
