using UnityEngine;
using UnityEngine.SceneManagement;

public class PIMenu : MonoBehaviour
{

    private int vidaPlayer;
    public void RestartGame()
    {
        FindObjectOfType<GameManager>().Restart();
    }
    public void AbreSceneTut()
    {
        SceneManager.LoadScene("Tutorial");
    }

    public void RestartGameCav()
    {
        Debug.Log("apertou butao restart");
        FindObjectOfType<GamePlayCavernaCanvas>().RestartLevelCaverna();
    }
    public void NextScene()
    {
        SceneManager.LoadScene("DialogueCaveIntro");
    }
}