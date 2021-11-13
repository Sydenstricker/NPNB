using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamePlayNaveCanvas : MonoBehaviour
{
    public DeathMenu deathMenu;
    public ScoreMenu scoreMenuNave;

    public void RestartGame()
    {
        Cursor.visible = true;
        Time.timeScale = 0.05f;
        //FindObjectOfType<cameraMovCav>().AtivaGlitchMorte(); concertar efeito glitch
        deathMenu.gameObject.SetActive(true);
    }
    public void RestartLevelCaverna()
    {
        SceneManager.LoadScene("CavernaGameplay");
    }
    public void AtivaScoreMenuNave()
    {
        Time.timeScale = 0.1f;
        Cursor.visible = true;
        scoreMenuNave.gameObject.SetActive(true);
    }
}
