using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamePlayCavernaCanvas : MonoBehaviour
{
    public DeathMenu deathMenu;    

    public void RestartGame()
    {
        Debug.Log("ativou menu morte cav gameplay");
        deathMenu.gameObject.SetActive(true);
    }
    public void RestartLevelCaverna()
    {
        SceneManager.LoadScene("CavernaGameplay");
        Debug.Log("restartou o level");
        //SceneLoader("GameplayCavernaGameplay");
    }
}
