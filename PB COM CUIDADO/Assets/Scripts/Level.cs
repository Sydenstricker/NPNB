using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Level : MonoBehaviour
{
    [SerializeField] float delayGameOver = 2f;
    [SerializeField] float delayGameOverCav = 2f;
    [SerializeField] float delayCinematicaFinal = 2f;

    public void LoadNextScene()
    {

        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);

        //  SceneManager.LoadScene(1);
        // SceneManager.LoadScene("NaveBlueGameplay");
    }

    public void LoadStartScene()
    {
        SceneManager.LoadScene(0);
    }

    public void LoadGameOverCav()
    {
        StartCoroutine((IEnumerator)WaitAndLoadCav());
    }
    IEnumerator WaitAndLoadCav()
    {
        yield return new WaitForSeconds(delayGameOverCav);
        SceneManager.LoadScene("CavGameover");

    }
    public void LoadGameOver()
    {
        StartCoroutine((IEnumerator)WaitAndLoad());
    }

    IEnumerator WaitAndLoad()
    {
        yield return new WaitForSeconds(delayGameOver);
        Cursor.visible = true;
        SceneManager.LoadScene("NaveBlueGameOver");

    }
    public void LoadCinematicaFinal()
    {
        StartCoroutine((IEnumerator)DelayCinematicaFinal());
    }
    public void LoadCinematicaFinalSemDelay()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("DialogueNaveEnd");
    }
    public void LoadCinematicaFinalSemDelayEN()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("DialogueNaveEndEN");
    }
    IEnumerator DelayCinematicaFinal()
    {
        yield return new WaitForSeconds(delayCinematicaFinal);
        SceneManager.LoadScene("DialogueNaveEnd");

    }
    public void QuitGame()
    {
        Application.Quit();

    }
}
