using System.Collections;
using System.Collections.Generic;
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
    }
    public void RestartLevelCaverna()
    {
        SceneManager.LoadScene("CavernaGameplay");       
    }
}
