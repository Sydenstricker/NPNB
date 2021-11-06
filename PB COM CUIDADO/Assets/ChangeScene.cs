using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    private float timeChangeScene = 8f;

    void Start()
    {
        Invoke("Change_Scene", timeChangeScene);
    }

    void Change_Scene()
    {
        SceneManager.LoadScene("HighScoreGlobal");
    }
}
