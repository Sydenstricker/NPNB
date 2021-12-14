using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathMenu : MonoBehaviour
{
    public string cena;
    public string cenaEN;
    private int vidaPlayer;
    [SerializeField] bool isNaveDesbugaSom = false;
    public void RestartGame()
    {
        FindObjectOfType<GameManager>().Restart();
    }
    public void AbreSceneTut()
    {
        SceneManager.LoadScene("Tutorial");

    }
    public void AbreSceneTutEN()
    {
        SceneManager.LoadScene("TutorialEN");

    }
    public void VoltarMenu()
    {
        if(isNaveDesbugaSom == true)
        {
            FindObjectOfType<MusicPlayer>().DesbugaMusicaDuplicada();
            SceneManager.LoadScene(cena);
        }
        else
            SceneManager.LoadScene(cena);
    }
    public void VoltarMenuEN()
    {
        if(isNaveDesbugaSom == true)
        {
            FindObjectOfType<MusicPlayer>().DesbugaMusicaDuplicada();
            SceneManager.LoadScene(cenaEN);
        }
        else
            SceneManager.LoadScene(cenaEN);
    }
    public void RestartGameCav()
    {
        Debug.Log("apertou butao restart");
        FindObjectOfType<GameSession>().ResetGame();
        SceneManager.LoadScene("CavernaGameplay");
        //FindObjectOfType<GamePlayCavernaCanvas>().RestartLevelCaverna();
    }
    public void RestartGameCavEN()
    {
        Debug.Log("apertou butao restart");
        FindObjectOfType<GameSession>().ResetGame();
        SceneManager.LoadScene("CavernaGameplayEN");
        //FindObjectOfType<GamePlayCavernaCanvas>().RestartLevelCaverna();
    }
    public void RestartGameNave()
    {
        FindObjectOfType<GameSession>().ResetGame();
        SceneManager.LoadScene("NaveBlueGameplay");
    }
    public void RestartGameNaveEN()
    {
        FindObjectOfType<GameSession>().ResetGame();
        SceneManager.LoadScene("NaveBlueGameplayEN");
    }
    public void NextScene()
    {
        SceneManager.LoadScene("DialogueCaveIntro");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
