using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string cena;
    public SoundManager soundManager;

    public void StartGame(){
        //soundManager.PlayAudio("startgame");
        SceneManager.LoadScene(cena);
    }
    public void QuitGame(){
        Application.Quit();

    }
}