using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamePlayNaveCanvas : MonoBehaviour
{
    public DeathMenu deathMenu;
    public ScoreMenu scoreMenuNave;

    public void RestartGame()
    {
        StartCoroutine("DeathMenuCo");
        Cursor.visible = true;
        Time.timeScale = 0.05f;
    }
    private IEnumerator DeathMenuCo()
    {
        yield return new WaitForSeconds(.1f);
        deathMenu.gameObject.SetActive(true);
        FindObjectOfType<cameraNaveGlitch>().AtivaGlitchMorte(); //consertar efeito glitch 
    }
    public void RestartLevelCaverna()
    {
        SceneManager.LoadScene("CavernaGameplay");
    }
    public void AtivaScoreMenuNave()
    {
        StartCoroutine("HighScoreCo");
        Time.timeScale = 0.05f;
        Cursor.visible = true;
    }
    private IEnumerator HighScoreCo()
    {
        yield return new WaitForSeconds(.5f);
        scoreMenuNave.gameObject.SetActive(true);
        FindObjectOfType<cameraNaveGlitch>().AtivaGlitchScore();
    }
}