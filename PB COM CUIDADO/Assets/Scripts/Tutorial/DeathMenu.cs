using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathMenu : MonoBehaviour
{
    public string cena;

    public void RestartGame()
    {
        FindObjectOfType<GameManager>().Restart();
    }

    public void VoltarMenu()
    {
        SceneManager.LoadScene(cena);
    }

}
