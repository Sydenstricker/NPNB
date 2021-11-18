using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 5f;

    public void LoadNextLevel()
    {

        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        // Play animation
        transition.SetTrigger("Start");

        //Wait
        yield return new WaitForSeconds(transitionTime);

        //Load scene
        SceneManager.LoadScene(levelIndex);
    }

    public void VoltaMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void RestartLevelTut()
    {
        FindObjectOfType<PauseMenu>().Resume();
        FindObjectOfType<GameSession>().ResetGame();
        SceneManager.LoadScene("Tutorial");
    }
    public void RestartLevelCav()
    {
        FindObjectOfType<PauseMenu>().Resume();
        FindObjectOfType<GameSession>().ResetGame();
        SceneManager.LoadScene("CavernaGameplay");
    }
    public void TerminouFaseCavernaGameplay()
    {
        //FindObjectOfType<GameManager>().
        SceneManager.LoadScene("DialogueCaveEnd");
    }
    public void RestartLevelNave()
    {
        FindObjectOfType<PauseMenu>().Resume();
        FindObjectOfType<GameSession>().ResetGame();
        SceneManager.LoadScene("NaveBlueGameplay");
    }

}
