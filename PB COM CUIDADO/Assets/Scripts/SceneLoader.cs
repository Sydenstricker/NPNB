using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {

	public void LoadNextScene()
    {
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
}
