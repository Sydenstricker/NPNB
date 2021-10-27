using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamePlayCavernaCanvas : MonoBehaviour
{
    public DeathMenu deathMenu;    

    public void RestartGame()
    {
        deathMenu.gameObject.SetActive(true);
    }
    public void RestartLevelCaverna()
    {
        SceneManager.LoadScene("CavernaGameplay");       
    }
}
