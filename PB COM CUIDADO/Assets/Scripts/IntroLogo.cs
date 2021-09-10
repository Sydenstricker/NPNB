using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroLogo : MonoBehaviour
{
    public int MainMenu;
    private float tempoMudaScene = 5f;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("Change_Scene",tempoMudaScene);
    }
    void Change_Scene()
    {
        SceneManager.LoadScene(MainMenu);
    }
}