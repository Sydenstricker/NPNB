using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroTutorial : MonoBehaviour
{
    public int Tutorial;
    private float tempoMudaScene = 10f;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("Change_Scene", tempoMudaScene);
    }
    void Change_Scene()
    {
        SceneManager.LoadScene("Tutorial");
    }
}

