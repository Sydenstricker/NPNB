using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string cena;
    public SoundManager soundManager;

    public void StartGame()
    {
        //soundManager.PlayAudio("startgame");
        SceneManager.LoadScene("Tutorial");
    }
    public void QuitGame()
    {
        Application.Quit();

    }
}