using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroLogo : MonoBehaviour
{
    public int MainMenu;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("Change_Scene", 10f);
    }
    void Change_Scene()
    {
        SceneManager.LoadScene(MainMenu);
    }
}