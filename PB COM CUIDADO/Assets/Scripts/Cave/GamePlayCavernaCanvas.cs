using UnityEngine;
using UnityEngine.SceneManagement;

public class GamePlayCavernaCanvas : MonoBehaviour
{
    public DeathMenu deathMenu;

    public void RestartGame()
    {
        Cursor.visible = true;
        FindObjectOfType<cameraMovCav>().AtivaGlitchMorte();
        deathMenu.gameObject.SetActive(true);
        FindObjectOfType<SoundManager>().TocaDeathMenu();
    }
    public void RestartLevelCaverna()
    {
        SceneManager.LoadScene("CavernaGameplay");
    }
}
