using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    private float timeChangeScene = 8f;
    [SerializeField] bool isEN = false;

    void Start()
    {
        if (isEN == false)
        {
            Invoke("Change_Scene", timeChangeScene);
        }
        else
        {
            Invoke("Change_SceneEN", timeChangeScene);
        }
    }

    void Change_Scene()
    {
        SceneManager.LoadScene("HighScoreGlobal");
    }
    void Change_SceneEN()
    {
        SceneManager.LoadScene("HighScoreGlobalEN");
    }
}
