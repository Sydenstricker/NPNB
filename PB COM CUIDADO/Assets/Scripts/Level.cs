using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Level : MonoBehaviour
{
    [SerializeField] float delayGameOver = 2f;
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
    public void LoadGameOver()
    {
       StartCoroutine((IEnumerator)WaitAndLoad());        
    }
    
    IEnumerator WaitAndLoad()
    {
        yield return new WaitForSeconds(delayGameOver);
        SceneManager.LoadScene("NaveBlueGameOver");

    }
    public void LoadCinematicaFinal()
    {
        StartCoroutine((IEnumerator)DelayCinematicaFinal());
    }
    IEnumerator DelayCinematicaFinal()
    {
        yield return new WaitForSeconds(delayCinematicaFinal);
        SceneManager.LoadScene("Cinematica Final");

    }
    public void QuitGame()
    {
        Application.Quit();
    
    }
}
