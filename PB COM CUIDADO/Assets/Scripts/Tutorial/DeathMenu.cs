using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathMenu : MonoBehaviour
{
    public string cena;
    private int vidaPlayer;
    public void RestartGame()
    {
        FindObjectOfType<GameManager>().Restart();
    }
    public void AbreSceneTut()
    {
        SceneManager.LoadScene("Tutorial");
        
    }
    public void VoltarMenu()
    {
        SceneManager.LoadScene(cena);
    }
    public void RestartGameCav()
    {
        Debug.Log("apertou butao restart");
        FindObjectOfType<GameSession>().ResetGame();
        SceneManager.LoadScene("CavernaGameplay");
        //FindObjectOfType<GamePlayCavernaCanvas>().RestartLevelCaverna();
    }
    public void NextScene()
    {
        SceneManager.LoadScene("DialogueCaveIntro");
    }
    public void QuitGame()
    {
        QuitGame();
    }
}
